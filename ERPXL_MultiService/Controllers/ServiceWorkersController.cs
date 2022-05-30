using ERPXL_MultiService.Base;
using ERPXL_MultiService.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPXL_MultiService.Controllers
{
    public class ServiceWorkersController : AbstractServiceWorkersController
    {
        public ServiceWorkersController() : base() {}

        public ServiceWorkersController(int interval) : base(interval) {}

        protected override void setWorkers()
        {
            /* Tu dodajemy nowe workery*/
            _workers.Add(new InvoiceSenderWorker());
        }
    }
}
