using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OOPEmployee
{
    internal class employeeSalaryDetails
    {
        public static void EmployeeDetails(Employee employee)
        {
            Console.WriteLine("Enter EMployee ID:");
            employee.employeeId = Convert.ToInt32(Console.ReadLine());

            //Reading the Employee  Details (Name,Contact Number,Basic Salary,Allowances,Deductions) of the Employee from the Console.
            Console.WriteLine("Enter employee name:");
            employee.employeeName = Console.ReadLine();

            Console.WriteLine("Enter employee contact number:");
            employee.employeeNumber = Convert.ToInt64(Console.ReadLine());


            Console.WriteLine("Enter basic salary: ");
            employee.basicSalary = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter HRA:");
            employee.HRA = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter dearness allowance:");
            employee.dearnessAllowance = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter conveyance allowance: ");
            employee.conveyanceAllowance = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter tax:");
            employee.tax = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter PF:");
            employee.PF = Convert.ToDecimal(Console.ReadLine());
        }
        static void Main(string[] args)
        {
            Employee employee = new Employee();
            EmployeeDetails(employee);
            decimal totalAllowance = employee.employeeAllowanceCal(employee.HRA, employee.dearnessAllowance, employee.conveyanceAllowance);
            decimal totalDeduction = employee.employeeDeductionCal(employee.PF, employee.tax);
            Console.WriteLine(employee.employeeSalaryCal(totalAllowance, totalDeduction));


        }
    }
}