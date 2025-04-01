using System;

namespace app_console.Dtos
{
    internal class Shifts
    {
        public int ShiftID { get; set; }

        public string ShiftName { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

    }
}
