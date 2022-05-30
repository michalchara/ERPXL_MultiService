using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPXL_MultiService.Base
{
    public enum ScheduleType
    {
        Minutely,
        Hourly,
        Daily,
        DailyWithoutWeekends,
        Weekly,
        Monthly,
    }
}
