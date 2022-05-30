using ERPXL_MultiService.Base;
using ERPXL_MultiService.Controllers;
using System.ServiceProcess;


namespace ERPXL_MultiService
{
    public partial class ERPXL_MultiService : ServiceBase
    {
        private AbstractServiceWorkersController serviceWorkersController;

        public ERPXL_MultiService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            serviceWorkersController = new ServiceWorkersController(30000); //30s
            serviceWorkersController.Start();
        }
        protected override void OnStop()
        {
            serviceWorkersController.Stop();
        }
    }
}
