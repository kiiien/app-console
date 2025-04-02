using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_console.DataAccessLayer
{
    internal class DAL_Attendance
    {
        ManageStaffEntities _context = new ManageStaffEntities();

        public List<Attendance> GetAllByIdStaff(int idStaff) => _context.Attendance.Where(a => a.EmployeeID == idStaff).ToList();

        public Salaries GetHourlyWageByIdStaff(int idStaff) => _context.Salaries.FirstOrDefault(a => a.EmployeeID == idStaff);

        public List<Attendance> GetAttendanceMoth()
        {
            DateTime dateTime = DateTime.Now;

            return _context.Attendance.Where(a => a.WorkDate.Month ==  dateTime.Month).ToList();
        }
    }
}
