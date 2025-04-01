using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_console.Dtos
{
    internal class Salaries
    {
        public int SalaryID { get; set; }

        public int EmployeeID { get; set; }

        public DateTime MonthYear { get; set; }

        public decimal TotalWorkHours { get; set; }

        public decimal HourlyWage { get; set; }

        public decimal TotalSalary { get; set; }

        public decimal Bonus { get; set; }

        public decimal Deductions { get; set; }

        public decimal FinalSalary { get; set; }

        public decimal Allowance { get; set; }

        public decimal OverTimeRate { get; set; }

        public int TotalOvertimeHours { get; set; }

        public decimal OverTimeSalary { get; set; }

        public decimal BaseSalary { get; set; }
    }
}
