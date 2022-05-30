using ERPXL_MultiService.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ERPXL_MultiService.Workers
{
    public class InvoiceSenderWorker : IWorker
    {
        #region implementacja interfejsu

        public string Name => GetType().Name;

        public ScheduleType WorkerScheduleType => ScheduleType.Minutely; //uruchamia się co {IntervalMultiplyer} minut
        public int StartHour => 0;    // o godzinie {StartHour}:{StartMinute} -> parametr ignorowany w przypadku ScheduleType.Minutely
        public int StartMinute => 0;  // o godzinie {StartHour}:{StartMinute} -> parametr ignorowany w przypadku ScheduleType.Minutely
        public int IntervalMultiplyer => 30; //w przypadku ScheduleType.Minutely uruchamia się co {IntervalMultiplyer} minut

        public Action GetAction()
        {
            return () =>
            {
                #region implementacja właściwa workera

                List<Task> tasks = new List<Task>();
                string connString = 
                @"Data Source=SERWER;Initial Catalog=ERPXL_Firma;Persist Security Info=True;User ID=sqlLogin;Password=sqlPass";
          
                DataTable invoiceList = getInvoiceList(connString);

                if (invoiceList.Rows.Count > 0)
                {
                    ERPXL_Login();
                    MailApi.MailApi.Enable("smtp.serwer", "password", "login", "sender.email");
                }

                foreach(DataRow row in invoiceList.Rows)
                {
                    int GIDNumer = (int)row["TrN_GIDNumer"];
                    int GidTyp = (int)row["TrN_GIDTyp"];
                    string email = (string)row["KnT_eMail"];
                    tasks.Add(Task.Run(() => DoWorkForDocument(GIDNumer, GidTyp, email)));
                }

                if (invoiceList.Rows.Count > 0)
                {
                    Task.WaitAll(tasks.ToArray());
                    ERPXL_Logout();
                    MailApi.MailApi.Disable();
                }
                    
                #endregion
            };
        }

        #endregion

        #region unikalny kod danego workera

        //zmienne potrzebne na potrzeby obsługi API ERP XL
        private const int XL_VERSION = 20220;
        private int _XLSessionId;


        private void ERPXL_Login()
        {
            cdn_api.XLLoginInfo_20220 loginInfo = new cdn_api.XLLoginInfo_20220();
            loginInfo.Wersja = XL_VERSION;
            loginInfo.Baza = "NazwaBazy";
            loginInfo.OpeIdent = "LoginOperatora";
            loginInfo.OpeHaslo = "HasłoOperatora";           
            cdn_api.cdn_api.XLLogin(loginInfo, ref _XLSessionId);
        }

        private void ERPXL_Logout()
        {
            cdn_api.cdn_api.XLLogout(_XLSessionId);
        }

        private string ERPXL_GenerateInvoice(int GIDNumer, int GIDTyp)
        {
            string fileName = $"{GIDNumer}_{DateTime.Now.ToString("yyyyMMddHHmmss")}.pdf";
            string sentInvoiceDir = @"D:\WyslaneFaktury";
            if (!Directory.Exists(sentInvoiceDir)) Directory.CreateDirectory(sentInvoiceDir);
            string path = Path.Combine(sentInvoiceDir, fileName);

            cdn_api.XLWydrukInfo_20220 wydrukInfo = new cdn_api.XLWydrukInfo_20220();
            wydrukInfo.Wersja = XL_VERSION;
            wydrukInfo.Zrodlo = 0;  // identyfikacja wydruku w systemie ERPXL
            wydrukInfo.Wydruk = 1029; // identyfikacja wydruku w systemie ERPXL
            wydrukInfo.Format = 51;  // identyfikacja wydruku w systemie ERPXL
            wydrukInfo.Urzadzenie = 2;
            wydrukInfo.FiltrSQL = $"(Trn_GIDTyp = {GIDTyp} AND Trn_GIDNumer = {GIDNumer})";
            wydrukInfo.DrukujDoPliku = 1;
            wydrukInfo.PlikDocelowy = path;

            int result = cdn_api.cdn_api.XLWykonajPodanyWydruk(wydrukInfo);

            if (result != 0) return null;
            return path;
        }

        private void ERPXL_DodajAtrybut(int GIDNumer, int GIDTyp)
        {          
            cdn_api.XLAtrybutInfo_20220 atrybutInfo = new cdn_api.XLAtrybutInfo_20220();
            atrybutInfo.Wersja = XL_VERSION;
            atrybutInfo.GIDTyp = GIDTyp;
            atrybutInfo.GIDNumer = GIDNumer;
            atrybutInfo.Klasa = "DataAutomatycznejWysylki";
            atrybutInfo.Wartosc = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            cdn_api.cdn_api.XLDodajAtrybut(_XLSessionId, atrybutInfo);
        }

        private void DoWorkForDocument(int GIDNumer, int GIDTyp, string email)
        {
            string pdfPath = ERPXL_GenerateInvoice(GIDNumer, GIDTyp);
            if (pdfPath == null) return;
            MailApi.MailApi.Api.SendEMailWithAttachment( "Faktura VAT", getEmailBody(), email, new List<string>(){ pdfPath } );
            ERPXL_DodajAtrybut(GIDNumer, GIDTyp);
        }

      

        private DataTable getInvoiceList(string con)
        {
            try
            {
                string query = @"
SELECT TrN_GIDNumer, TrN_GIDTyp, KnT_eMail
FROM CDN.TraNag 
INNER JOIN CDN.KntKarty ON TrN_KntNumer = Knt_GIDNumer AND TrN_KntTyp = Knt_GIDTyp
INNER JOIN CDN.Atrybuty ON TrN_GIDNumer = Atr_ObiNumer AND TrN_GIDTyp = Atr_ObiTyp 
    AND Atr_AtkID = ( SELECT Atk_ID FROM CDN.AtrybutyKlasy WHERE Atk_Nazwa = 'DataAutomatycznejWysylki' )
WHERE
TrN_Stan IN (3,4,5)
AND LTRIM(Knt_eMail) <> ''
AND ( Atr_Wartosc IS NULL OR LTRIM(Atr_Wartosc) = '' )";

                using (SqlDataAdapter sqlDA = new SqlDataAdapter(query, con))
                {
                    DataSet ds = new DataSet();
                    sqlDA.Fill(ds);
                    return ds.Tables[0];
                }
            }
            catch { return new DataTable(); }          
        }

        private string getEmailBody()
        {
            return @"
Dzień dobry,
W załączniku znajduje się faktura VAT.
Pozdrawiamy,
Firma";          
        }


        #endregion

    }

}
