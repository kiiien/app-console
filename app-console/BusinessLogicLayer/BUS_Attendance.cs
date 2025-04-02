using System;
using System.Collections.Generic;
using app_console.DataAccessLayer;

namespace app_console.BusinessLogicLayer
{
    internal class BUS_Attendance
    {
        DAL_Attendance _attendance = new DAL_Attendance();
        DAL_Employees _employees = new DAL_Employees();


        public void Title()
        {
            Console.WriteLine("======== Tính bảng lương ========");

            Console.WriteLine();

            List<Employees> employees = _employees.GetAll();

            foreach (Employees employee in employees)
            {
                List<Attendance> attendances = _attendance.GetAllByIdStaff(employee.EmployeeID);

                Salaries salaries = _attendance.GetHourlyWageByIdStaff(employee.EmployeeID);

                Console.WriteLine($"Id: {employee.EmployeeID} | Full Name: {employee.FullName} | Phone: {employee.Phone} | Email: {employee.Email} | Address: {employee.Address} | TotalSalary: {HandleFunc(attendances, salaries)}");
            }
        }

        public decimal HandleFunc(List<Attendance> attendances, Salaries salaries)
        {
            decimal totalHour = 0;

            foreach (Attendance att in attendances)
            {
                TimeSpan workingTime = (TimeSpan)att.CheckOut - att.CheckIn;
                if (workingTime.TotalHours < 0)
                {
                    workingTime += TimeSpan.FromDays(1); // Cộng thêm 1 ngày nếu CheckOut nhỏ hơn CheckIn
                }
                totalHour += (decimal)workingTime.TotalHours;
            }

            return totalHour * salaries.HourlyWage;
        }

        public void FinalFunc()
        {
            while (true)
            {
                Title();

                Console.WriteLine();

                Console.Write("Bạn có muốn tiếp tục không (Y/N): ");

                string select = Console.ReadLine();

                if(select.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
            }
        }
    }
}
