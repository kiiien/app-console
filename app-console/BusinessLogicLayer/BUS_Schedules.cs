using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app_console.DataAccessLayer;

namespace app_console.BusinessLogicLayer
{
    internal class BUS_Schedules
    {
        DAL_Schedules _schedules = new DAL_Schedules();
        DAL_Employees _employees = new DAL_Employees();
        DAL_Shifts _shifts = new DAL_Shifts();

        public int Title()
        {
            Console.Clear();

            Console.WriteLine("========== Cập nhật ca làm cho nhân viên ==========");

            Console.WriteLine();

            Console.Write("Nhập mã nhân viên cần cập nhật ca làm: ");

            int idStaff = int.Parse(Console.ReadLine());

            return idStaff;
        }

        public void ExportSchedules(Employees employees, List<Schedules> schedules)
        {
            Console.WriteLine("========== Cập nhật ca làm cho nhân viên ==========");

            Console.WriteLine();

            Console.WriteLine("*Thông tin nhân viên");

            employees.Export();

            Console.WriteLine();

            Console.WriteLine($"Thông tin ca làm của - {employees.FullName}");
            Console.WriteLine("==============================================");

            foreach (Schedules schedule in schedules)
            {
                schedule.Export();
            }

            Console.WriteLine();
        }

        public void ExportShifts(Employees employees, Schedules schedule, List<Shifts> shifts)
        {
            Console.Clear();

            List<Schedules> schedules = new List<Schedules>();

            schedules.Add(schedule);

            ExportSchedules(employees, schedules);

            Console.WriteLine("========== Ca làm có thể đăng ký ==========");

            Console.WriteLine();

            foreach(Shifts shift in shifts)
            {
                shift.Export();
            }

            Console.WriteLine();
        }

        public void HandleFunc()
        {
            int idStaff = Title();

            Employees employees = _employees.GetById(idStaff);

            List<Schedules> schedules = _schedules.GetAllSchedulesByIdStaff(idStaff);

            Console.Clear();

            ExportSchedules(employees, schedules);

            Console.Write("Nhập mã ca làm cần cập nhật: ");

            int schedule = int.Parse(Console.ReadLine());

            Schedules scheduled = schedules.FirstOrDefault(a => a.ScheduleID == schedule);

            List<Shifts> shifts = _shifts.GetAllShifts();

            ExportShifts(employees, scheduled, shifts);

            Console.Write("*Nhập mã ca làm mong muốn: "); 

            int shift = int.Parse(Console.ReadLine());

            scheduled.ShiftID = shift;

            Schedules existing = _schedules.Update(scheduled);

            if(existing == null)
            {
                Console.WriteLine("Có lỗi xẩy ra khi cập nhật");

                return;
            }

            Console.WriteLine();

            Console.WriteLine("====== CẬP NHẬT THÀNH CÔNG ======");
        }

        public void FinalFunc()
        {
            while(true)
            {
                Console.Clear();

                HandleFunc();

                Console.WriteLine();

                Console.Write("Bạn có muốn tiếp tục không (Y/N): ");

                string selected = Console.ReadLine();

                if(selected.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
            }
        }
    }
}
