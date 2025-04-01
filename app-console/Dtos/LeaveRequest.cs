using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_console.Dtos
{
    internal class LeaveRequest
    {
        public string LeaveRequestID { get; set; }

        public int EmployeeID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; } 

        public string LeaveType { get; set; }

        public string Reason { get; set; }

        public string Status { get; set; }

        [Timestamp]
        public byte[] RequestDate { get; set; }
    }
}
