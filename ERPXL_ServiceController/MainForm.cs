using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.ServiceProcess;
using System.IO;
using ERPXL_MultiService.Controllers;

namespace ERPXL_ServiceController
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void InstallServiceButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(System.IO.Path.Combine(Environment.CurrentDirectory, "InstallFiles/InstallService.bat"));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas instalowania usługi: {Environment.NewLine + ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UninstallServiceButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(System.IO.Path.Combine(Environment.CurrentDirectory, "InstallFiles/UninstallService.bat"));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas odinstalowywania usługi: {Environment.NewLine + ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ServiceStatusButton_Click(object sender, EventArgs e)
        {
            try
            {           
                ServiceController sc = new ServiceController("ERPXL_MultiService");
                MessageBox.Show(sc.Status.ToString(), "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas sprawdzania statusu usługi: {Environment.NewLine + ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StartServiceButton_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceController sc = new ServiceController("ERPXL_MultiService");
                sc.Start();
                MessageBox.Show($"Usługa wystartowała", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas uruchamiania usługi: {Environment.NewLine + ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StopServiceButton_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceController sc = new ServiceController("ERPXL_MultiService");
                sc.Stop();
                MessageBox.Show($"Usługa została zatrzymana", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas zatrzymywania usługi: {Environment.NewLine + ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
     

        private void MainForm_Load(object sender, EventArgs e)
        {        
            WorkersListBox.DataSource = ServiceWorkersController.GetNamesOfRegistredWorkers<ServiceWorkersController>();
        }
    }
}
