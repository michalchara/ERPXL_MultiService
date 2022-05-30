using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPXL_MultiService.Base
{
    class ServiceTask : Task
    {
        public ServiceTask(IWorker worker) : base(worker.GetAction())
        {
            setDates(worker);
            Name = worker.Name;
        }
        private DateTime ExecuteDate { get; set; }
        public string Name { get; private set; }
        public bool CanBeRemoved { get => this.IsCompleted; }
        private bool CanBeStarted { get => this.Status != TaskStatus.Running && !this.IsCompleted && DateTime.Now > ExecuteDate; }

        public void StartIfReady()
        {
            if (CanBeStarted)
                Start();
        }

        private void setDates(IWorker worker)
        {
            #region mechanizm ustawiania daty i godziny kolejnego uruchomienia workera
            ScheduleType schedule = worker.WorkerScheduleType;
            int startHour = worker.StartHour;
            int startMinute = worker.StartMinute;
            int intervalMultiplyer = worker.IntervalMultiplyer;

            if (schedule == ScheduleType.Minutely)
            {
                ExecuteDate = DateTime.Now.AddMinutes(1 * intervalMultiplyer);
            }
            else if (schedule == ScheduleType.Hourly)
            {
                ExecuteDate = DateTime.Today.AddHours(DateTime.Now.Hour).AddMinutes(startMinute).AddHours(1 * intervalMultiplyer);
            }
            else if (schedule == ScheduleType.Daily)
            {
                ExecuteDate = DateTime.Today.AddHours(startHour).AddMinutes(startMinute);
                if(ExecuteDate < DateTime.Now)
                {
                    ExecuteDate = ExecuteDate.AddDays(1 * intervalMultiplyer);
                }                   
            }
            else if (schedule == ScheduleType.DailyWithoutWeekends)
            {
                ExecuteDate = DateTime.Today.AddHours(startHour).AddMinutes(startMinute);
                if (ExecuteDate < DateTime.Now)
                {
                    ExecuteDate = ExecuteDate.AddDays(1 * intervalMultiplyer);
                }                        

                if (ExecuteDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    ExecuteDate = ExecuteDate.AddDays(2);
                }
                else if (ExecuteDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    ExecuteDate = ExecuteDate.AddDays(1);
                }
            }
            else if (schedule == ScheduleType.Weekly)
            {
                ExecuteDate = DateTime.Today.AddHours(startHour).AddMinutes(startMinute);
                if (ExecuteDate < DateTime.Now)
                {
                    ExecuteDate = ExecuteDate.AddDays(7 * intervalMultiplyer);
                }
            }
            else if (schedule == ScheduleType.Monthly)
            {
                ExecuteDate = DateTime.Today.AddHours(startHour).AddMinutes(startMinute);
                if (ExecuteDate < DateTime.Now)
                {
                    ExecuteDate = ExecuteDate.AddMonths(1 * intervalMultiplyer);
                }
            }
            else
            {
                ExecuteDate = DateTime.Now;
            }
            #endregion
        }
    }

}
