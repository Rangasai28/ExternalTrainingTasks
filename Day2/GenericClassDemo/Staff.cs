using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace GenericClassDemo
{
    public class Staff : Person
    {
        public decimal Salary { get; set; }

        public string Department { get; set; }

        public Staff(int id, string name, int age, int number, decimal salary, string department)
        {
            Id = id;
            Name = name;
            Age = age;
            ContactNumber = number;
            Salary = salary;
            Department = department;
        }

        public override string getDetails()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Id  = {0}{1}", Id, Environment.NewLine);
            sb.AppendFormat("Name  = {0}{1}", Name, Environment.NewLine);
            sb.AppendFormat("Age  = {0}{1}", Age, Environment.NewLine);
            sb.AppendFormat("Salary  = {0}{1}", Salary, Environment.NewLine);
            sb.AppendFormat("Department  = {0}{1}", Department, Environment.NewLine);
            sb.AppendFormat("ContactNumber  = {0}{1}", ContactNumber, Environment.NewLine);


            return sb.ToString();
        }
    }
}
