using System;
using System.Collections.Generic;
using System.Linq;

namespace app_console.DataAccessLayer
{
    internal class DAL_Employees
    {
        ManageStaffEntities _context = new ManageStaffEntities();

        public Employees Update(Employees model)
        {
            try
            {
                _context.Entry(model);
                _context.SaveChanges();
               
                return model;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public Employees GetById(int id) => _context.Employees.FirstOrDefault(a => a.EmployeeID == id);

        public List<Employees> GetAll() => _context.Employees.ToList();
    }
}
