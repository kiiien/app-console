using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_console.DataAccessLayer
{
    internal class DAL_Shifts
    {
        ManageStaffEntities _context = new ManageStaffEntities();

        public List<Shifts> GetAllShifts() => _context.Shifts.ToList();
    }
}
