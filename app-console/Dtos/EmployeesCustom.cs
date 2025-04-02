using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_console.Dtos
{
    internal class EmployeesCustom
    {
        public int EmployeeID { get; set; }

        public string FullName { get; set; }

        public DateTime BirthDate { get; set; }

        public bool Gender { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Position { get; set; }

        public DateTime HireDate { get; set; }

        public decimal TotalHour { get; set; }

        public void Export() => Console.WriteLine($"Id: {this.EmployeeID} | Full Name: {this.FullName} | Phone: {this.Phone} | Email: {this.Email} | Address: {this.Address} | TotalHour: {this.TotalHour}h");

    }
}
