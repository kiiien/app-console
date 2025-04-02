using System;
using System.Collections.Generic;
using System.Linq;

namespace app_console.DataAccessLayer
{
    internal class DAL_Schedules
    {
        ManageStaffEntities _context = new ManageStaffEntities();

        public Schedules GetSchedulesByIdStaff(int idStaff) => _context.Schedules.FirstOrDefault(a => a.EmployeeID == idStaff);

        public List<Schedules> GetAllSchedulesByIdStaff(int idStaff) => _context.Schedules.Where(a => a.EmployeeID == idStaff).ToList();

        public Schedules GetSchedulesById(int id) => _context.Schedules.FirstOrDefault(a => a.ScheduleID == id);

        public Schedules Update(Schedules model)
        {
            try
            {
                _context.Entry(model);
                _context.SaveChanges();

                return model;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
