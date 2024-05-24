using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCRUD
{
    public  class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public long ContactNumber { get; set; }

        public decimal Salary {  get; set; }

        public Employee()
        {

        }
        public Employee(int id,string name,long contactnumber,decimal salary)
        {
            Id = id;    
            Name = name;
            ContactNumber = contactnumber;
            Salary = salary;
        }
    }
}
