using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_console.Dtos
{
    internal class Schedules
    {
        public int ScheduleID { get; set; }

        public int EmployeeID { get; set; }

        public int ShiftID { get; set; }

        public DateTime WorkDate { get; set; }
    }
}
