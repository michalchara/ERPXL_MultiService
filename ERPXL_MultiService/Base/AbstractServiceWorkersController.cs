using ERPXL_MultiService.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ERPXL_MultiService.Base
{
    public abstract class AbstractServiceWorkersController : Timer
    {
        private List<ServiceTask> _activeTasks = new List<ServiceTask>();
        protected List<IWorker> _workers = new List<IWorker>();

        public AbstractServiceWorkersController()
        {
            setWorkers();
        }

        public AbstractServiceWorkersController(int interval) : base(interval)
        {
            setWorkers();
            Elapsed += async (sender, e) => await manageWorkers();
        }

        protected abstract void setWorkers();
                 
        private Task manageWorkers()
        {
            return Task.Run(
               () =>
                {
                    #region mechanizm obsługi workerów

                    _activeTasks.RemoveAll(t => t.CanBeRemoved);

                    foreach (IWorker w in _workers)
                    {
                        if (!_activeTasks.Any(t => t.Name == w.Name))
                        {
                            _activeTasks.Add(new ServiceTask(w));
                        }
                    }

                    foreach (ServiceTask task in _activeTasks)
                    {
                        task.StartIfReady();
                    }
                    #endregion
                }
            );                               
        }


        static public List<string> GetNamesOfRegistredWorkers<T>() where T : AbstractServiceWorkersController, new()
        {           
            return new T()._workers.Select(w => w.Name).ToList(); 
        }

    }
}