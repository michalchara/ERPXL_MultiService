
namespace ERPXL_MultiService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ERPXL_MultiServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.ERPXL_MultiServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // ERPXL_MultiServiceProcessInstaller
            // 
            this.ERPXL_MultiServiceProcessInstaller.Password = null;
            this.ERPXL_MultiServiceProcessInstaller.Username = null;
            // 
            // ERPXL_MultiServiceInstaller
            // 
            this.ERPXL_MultiServiceInstaller.ServiceName = "ERPXL_MultiService";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.ERPXL_MultiServiceProcessInstaller,
            this.ERPXL_MultiServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller ERPXL_MultiServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller ERPXL_MultiServiceInstaller;
    }
}