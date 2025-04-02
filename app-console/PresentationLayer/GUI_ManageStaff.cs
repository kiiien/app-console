
using System;
using System.Text;
using app_console.BusinessLogicLayer;

namespace app_console.PresentationLayer
{
    internal class GUI_ManageStaff
    {

        BUS_Employees _employees = new BUS_Employees();
        BUS_Schedules _schedules = new BUS_Schedules();
        public void ExportMenu()
        {
            Console.WriteLine("============= MENU =============");
            
            Console.WriteLine();

            Console.WriteLine("1. Cập nhật thông tin nhân viên ");
            Console.WriteLine("2. Cập nhật ca làm nhân viên ");
            Console.WriteLine("3. Tính bảng lương");
            Console.WriteLine("4. Thống kê nhân viên");
            Console.WriteLine("5. *Thoát");
        }

        public void Test()
        {
            while (true)
            {
                Console.Clear();

                ExportMenu();

                Console.WriteLine();

                Console.Write("*Nhập lựa chọn của bạn: ");
                int selected = int.Parse(Console.ReadLine());

                switch (selected)
                {
                    case 1:
                        Console.Clear();

                        _employees.FinalFunctionUpdate();

                        break;
                    case 2:
                        Console.Clear();

                        _schedules.FinalFunc();
                        
                        break;

                    case 5:
                        return;
                        break;
                }

            }

        }
    }
}
