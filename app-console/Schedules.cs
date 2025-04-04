//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace app_console
{
    using System;
    using System.Collections.Generic;
    
    public partial class Schedules
    {
        public int ScheduleID { get; set; }
        public int EmployeeID { get; set; }
        public int ShiftID { get; set; }
        public System.DateTime WorkDate { get; set; }
    
        public virtual Employees Employees { get; set; }
        public virtual Shifts Shifts { get; set; }

        public void Export()
        {
            Console.WriteLine($"ScheduleId: CL-{this.ScheduleID} | ShiftID: {this.ShiftID} | WorkDate: {this.WorkDate.ToString("dd/MM/yyyy")} | ");
        }
    }
}
