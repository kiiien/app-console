
using System.Text;
using System;
using app_console.PresentationLayer;

namespace app_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            GUI_ManageStaff _UI = new GUI_ManageStaff();

            _UI.Test();

            Console.ReadKey();
        }
    }
}
