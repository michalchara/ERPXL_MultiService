using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace MailApi
{
    public static class MailApi
    {

        private static MailApiClass _api;

        public static MailApiClass Api
        {
            get { return _api; }
        }

        public static bool Enable(string smtpserver, string pass, string login, string senderEmail)
        {
            _api = new MailApiClass(smtpserver, pass, login, senderEmail);
            return true;
        }


        public static bool Enable(string smtpserver, string pass, string login, string senderEmail, int port, bool enableSSL)
        {
            _api = new MailApiClass(smtpserver, pass, login, senderEmail, port, enableSSL);
            return true;
        }

        public static bool Disable()
        {
            _api = null;
            return true;
        }

    }


    public class MailApiClass
    {

        public System.Globalization.CultureInfo Kulturka;

        private string _smtpserver;
        private string _pass;
        private string _login;
        private string _senderMail;
        private bool _enableSSL;
        private int _port;

        public string SenderMail
        {
            get { return _senderMail; }
            set { _senderMail = value; }
        }

        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

        public string Pass
        {
            get { return _pass; }
            set { _pass = value; }
        }

        public string Smtpserver
        {
            get { return _smtpserver; }
            set { _smtpserver = value; }
        }

        public bool EnableSSL { get => _enableSSL; set => _enableSSL = value; }
        public int Port { get => _port; set => _port = value; }


        public MailApiClass(string smtpserver, string pass, string login, string email)
        {
            this._smtpserver = smtpserver;
            this._pass = pass;
            this._login = login;
            this._senderMail = email;
            this._enableSSL = false;
            this._port = 0;
        }

        public MailApiClass(string smtpserver, string pass, string login, string email, int port, bool enableSSL)
        {
            this._smtpserver = smtpserver;
            this._pass = pass;
            this._login = login;
            this._senderMail = email;
            this._port = port;
            this._enableSSL = enableSSL;
        }



        public void SendEMailWithAttachment(string emailSubject, string emailBody, string emailAdress, List<string> attachmentPaths)
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(this._smtpserver);

            mail.From = new MailAddress(this._senderMail);
            mail.To.Add(emailAdress);
            mail.Subject = emailSubject;
            mail.Body = emailBody;

            System.Net.Mail.Attachment attachment;
            foreach (string att in attachmentPaths)
            {
                attachment = new System.Net.Mail.Attachment(att);
                mail.Attachments.Add(attachment);
            }

            SmtpServer.EnableSsl = this._enableSSL;

            if (this._port > 0)
            {
                SmtpServer.Port = this._port;
            }

            SmtpServer.Credentials = new System.Net.NetworkCredential(this._login, this._pass);
            SmtpServer.Send(mail);
        }

        public void SendEMail(string emailSubject, string emailBody, string emailAdress)
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(this._smtpserver);
            mail.From = new MailAddress(this._senderMail);
            mail.To.Add(emailAdress);
            mail.Subject = emailSubject;
            mail.Body = emailBody;

            SmtpServer.EnableSsl = this._enableSSL;

            if (this._port > 0)
            {
                SmtpServer.Port = this._port;
            }

            SmtpServer.Credentials = new System.Net.NetworkCredential(this._login, this._pass);

            SmtpServer.Send(mail);
        }


    }

}