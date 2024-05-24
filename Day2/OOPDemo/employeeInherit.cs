


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo
{
    public class employeeInherit : Person
    {
        private string _department;
        private decimal _salary;
        private string _role;

        public string department
        {
            get { return _department; }
            set { _department = value; }
        }

        public decimal salary
        {
            get { return _salary; }
            set { _salary = value; }
        }
        public string role
        { 
            get { return _role; } set {  _role = value; } 
        }

        public static void Main(string[] args)
        {
            employeeInherit employeeOne = new employeeInherit();

            employeeOne.name = "Ranga";
            employeeOne.age = 30;
            employeeOne.gender = 'M';
            employeeOne.salary = 30000;
            employeeOne.contactNumber = 3905353020;
            employeeOne.department = "IT";
            employeeOne.role = "Associate Engineer";

            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} ", employeeOne.name, employeeOne.salary, employeeOne.department, employeeOne.age, employeeOne.gender, employeeOne.role, employeeOne.contactNumber);

        }
    }
}
