using System.Collections.Generic;
using app_console.DataAccessLayer;

namespace app_console.BusinessLogicLayer
{
    internal class BUS_Shifts
    {
        DAL_Shifts _Shifts = new DAL_Shifts();

        public void Export()
        {
            List<Shifts> shifts = _Shifts.GetAllShifts();

            Shifts shifts1 = new Shifts();
        }
    }
}
