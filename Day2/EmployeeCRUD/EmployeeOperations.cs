using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static EmployeeCRUD.Program;

namespace EmployeeCRUD
{
    public  class EmployeeOperations
    {
       


        public  ArrayList EmployeeList = new ArrayList();
        public  void  AddEmployee(Employee employee)
        {
           EmployeeList.Add(employee);
            
        }
        
        public  void DeleteEmployee(int index)
        {
            
            EmployeeList.RemoveAt(index);

        }

        public void UpdateEmployee(Employee newEmp ,int id)
        {

            foreach(Employee emp in EmployeeList)
            {
                if(emp.Id == id)
                {
                    emp.Name = newEmp.Name;
                    emp.ContactNumber = newEmp.ContactNumber;
                    emp.Salary = newEmp.Salary;
                }
            }

        }

        

        public ArrayList getEmployeeList()
        {
            return EmployeeList;
        }

    }
}
