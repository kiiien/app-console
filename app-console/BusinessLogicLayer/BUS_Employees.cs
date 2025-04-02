
using System;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using app_console.DataAccessLayer;

namespace app_console.BusinessLogicLayer
{
    internal class BUS_Employees
    {
        DAL_Employees _context = new DAL_Employees();
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
