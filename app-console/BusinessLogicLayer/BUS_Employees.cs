
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using app_console.DataAccessLayer;
using app_console.Dtos;

namespace app_console.BusinessLogicLayer
{
    internal class BUS_Employees
    {
        DAL_Employees _context = new DAL_Employees();
        DAL_Attendance _attendance = new DAL_Attendance();

        // thông nhân viên

        // thống kê tổng thời gian làm của nhân viên
        public void TotalHourWork()
        {
            Console.WriteLine("=========== Thông kê giờ làm ===========");

            Console.WriteLine();

            List<Employees> employees = _context.GetAll();

            foreach(Employees employee in employees)
            {
                List<Attendance> attendances = _attendance.GetAllByIdStaff(employee.EmployeeID);

                Console.WriteLine($"Id: {employee.EmployeeID} | Full Name: {employee.FullName} | Phone: {employee.Phone} | Email: {employee.Email} | Address: {employee.Address} | TotalHour: {HandleTotalWork(attendances)}h");

            }
        }

        public decimal HandleTotalWork(List<Attendance> attendances)
        {
            decimal total = 0;

            foreach(Attendance att in attendances)
            {
                TimeSpan workingTime = (TimeSpan)att.CheckOut - att.CheckIn;
                if (workingTime.TotalHours < 0)
                {
                    workingTime += TimeSpan.FromDays(1); // Cộng thêm 1 ngày nếu CheckOut nhỏ hơn CheckIn
                }

                total += (decimal)workingTime.TotalHours;
            }

            return total;
        }

        // Xuất 2 nhân viên có tổng giờ làm việc nhất/thấp nhất trong tháng

        public void HourCompare()
        {
            Console.WriteLine("=========== Thông kê nhân viên có nhiều/ít giờ làm nhất ===========");

            Console.WriteLine();

            List<Attendance> attendances = _attendance.GetAttendanceMoth();

            List<Employees> employees = _context.GetAll();

            List<EmployeesCustom> emp = new List<EmployeesCustom>();

            foreach(Employees employee in employees)
            {
                List<Attendance> atten = attendances.Where(a => a.EmployeeID == employee.EmployeeID).ToList();

                EmployeesCustom employeeCustom = new EmployeesCustom
                {
                    EmployeeID = employee.EmployeeID,
                    FullName = employee.FullName,
                    Address = employee.Address,
                    Email = employee.Email,
                    Phone = employee.Phone,
                    TotalHour = HandleTotalWork(atten)
                };

                emp.Add(employeeCustom);
            }

            EmployeesCustom lowest = emp.OrderByDescending(a => a.TotalHour).FirstOrDefault();
            EmployeesCustom highest = emp.OrderBy(a => a.TotalHour).FirstOrDefault();

            lowest.Export();

            highest.Export();
        }



        public void MainTitle()
        {
            Console.WriteLine("======== Thông kê nhân viên =========");
            Console.WriteLine("1. Thông kê tất cả giờ làm cửa từng nhân viên");
            Console.WriteLine("2. Nhân viên có nhiều giờ làm nhất/thấp nhất trong tháng");
            Console.WriteLine("3. *Thoát");

            Console.WriteLine();

            Console.Write("Nhập lựa chọn của bạn: ");

            int select = int.Parse(Console.ReadLine());

            switch (select)
            {
                case 1:

                    Console.Clear();

                    TotalHourWork();
                    
                    break;

                case 2:
                    Console.Clear();

                    HourCompare();

                    break;

                case 3:
                    return;
            }

        }

        public void FinalFunc()
        {
            while (true)
            {
                Console.Clear();

                MainTitle();

                Console.WriteLine();

                Console.Write("Bạn có muốn tiếp tục không (Y/N): ");
                
                string selected = Console.ReadLine();

                if(selected.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
            }
        }


        // update info staff

        public void TitleUpdateInfo()
        {
            Console.WriteLine("====== Cập nhật thông tin nhân viên ======");
            Console.WriteLine();
        }

        public bool TestInput(int id)
        {
            return Regex.IsMatch(id.ToString(), @"^\d+$");
        }

        public Employees GetStaffById(int id) => _context.GetById(id);

        public string Input(string text)
        {
            string a = text;
            while (true)
            {
                Console.WriteLine();

                Console.Write($"Nhập {a} của nhân viên: ");

                text = Console.ReadLine();

                if(text.Trim().Length > 0 )
                {
                    
                    return text;
                }
            }
        }

        public Tuple<string, string, string> InputByUser()
        {
            string phone, address, email;

            phone = Input("phone");
            address = Input("address");
            email = Input("email");

            return Tuple.Create(phone, address, email);
        }
        
        public void Update()
        {
            TitleUpdateInfo(); // tiêu đề chức năng

            Console.Write("- Nhập mã nhân viên ( *chỉ nhập chữ số ): ");
            int idStaff = int.Parse(Console.ReadLine());

            Console.WriteLine();

            bool isOnlyNumber = TestInput(idStaff);
            
            while (!isOnlyNumber)
            {
                continue;
            }

            // get info staff by id for input to user

            Employees employee = _context.GetById(idStaff);

            if (employee == null)
            {
                Console.WriteLine($"====== KHÔNG TÌM THẤY THÔNG TIN NHÂN VIÊN CÓ MÃ {idStaff} ======");
                return;
            }


            Console.WriteLine($"====== Thông tin nhân viên TRƯỚC khi cập nhật ( MÃ {idStaff} ) ======");

            employee.Export();

            Tuple<string, string, string> newInfor =  InputByUser();

            employee.Phone = newInfor.Item1; 
            employee.Address = newInfor.Item2;
            employee.Email = newInfor.Item3;

            Employees existing = _context.Update(employee);
            
            if(existing == null)
            {
                Console.WriteLine("Có lỗi trong quá trình cập nhật");
                Console.WriteLine();
                
                return;
            }

            Console.WriteLine($"====== Thông tin nhân viên SAU khi cập nhật ( MÃ {idStaff} ) ======");

            existing.Export();

        }

        public void FinalFunctionUpdate() // Hàm chạy chính trong chức năng cập nhật thông tin
        {
            while (true)
            {
                Console.Clear();

                Update();

                Console.WriteLine();

                Console.Write("Bạn có muốn tiếp tục không (Y/N): ");

                string select = Console.ReadLine();

                if (select.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
            }
        }
    }
}
