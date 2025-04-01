
using System;
using System.Text;
using app_console.BusinessLogicLayer;

namespace app_console.PresentationLayer
{
    internal class GUI_ManageStaff
    {

        BUS_Employees _employees = new BUS_Employees();
        public void ExportMenu()
        {
            Console.WriteLine("============= MENU =============");
            
            Console.WriteLine();

            Console.WriteLine("1. Cập nhật thông tin nhân viên ");
            Console.WriteLine("2. Cập nhật ca làm nhân viên ");
            Console.WriteLine("3. Tính bảng lương");
            Console.WriteLine("4. Thống kê nhân viên");
        }

        public void Test()
        {
            _employees.FinalFunctionUpdate();
        }
    }
}
