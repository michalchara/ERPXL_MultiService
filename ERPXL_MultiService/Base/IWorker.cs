using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPXL_MultiService.Base
{
    public interface IWorker
    {
        string Name { get; }
        int StartHour { get; }
        int StartMinute { get; }
        int IntervalMultiplyer { get; }
        ScheduleType WorkerScheduleType { get; }

        Action GetAction();
    }
}
