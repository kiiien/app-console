using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_console.Dtos
{
    public class Attendance
    {
        public int AttendanceID { get; set; }

        public int EmployeeID { get; set; }

        public int ShiftID { get; set; }

        public DateTime WorkDate { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public decimal TotalHours { get; set; }

        public string Status { get; set; }

        public string Notes { get; set; }
    }
}
