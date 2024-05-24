/*
 * Employee.cs
 * This Program defines Fields,Properties and methods that are used to calculate netSalary of n Employee.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEmployee
{
    public class Employee
    {   

        //Declaring Fields
        private int _employeeID;
        private string _employeeName;
        private long _employeeNumber;
        private decimal _basicSalary, _HRA, _dearnessAllowance, _conveyanceAllowance, _tax, _PF, _totalAllowances, _totalDeductions, _totalSalary;

        //Defining the Properties for the above Mentioned Fields
        public int employeeId
        {
            get { return _employeeID; }
            set { _employeeID = value; }
        }
        public string employeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }

        public long employeeNumber
        {
            get { return _employeeNumber; }
            set { _employeeNumber = value; }
        }

        public decimal basicSalary
        {
            get { return _basicSalary; }
            set { _basicSalary = value; }
        }

        public decimal HRA
        {
            get { return _HRA; }
            set { _HRA = value; }
        }

        public decimal dearnessAllowance
        {
            get { return _dearnessAllowance; }
            set { _dearnessAllowance = value; }
        }
        public decimal conveyanceAllowance
        {
            get { return _conveyanceAllowance; }
            set { _conveyanceAllowance = value; }
        }

        public decimal tax
        {
            get { return _tax; }
            set { _tax = value; }
        }

        public decimal PF
        {
            get { return _PF; }
            set { _PF = value; }
        }

        public decimal totalAllowances
        {
            get { return _totalAllowances; }
            set { _totalAllowances = value; }
        }

        public decimal totalDeductions
        {
            get { return _totalDeductions; }
            set { _totalDeductions = value; }
        }

        public decimal totalSalary
        {
            get { return _totalSalary; }
            set { _totalSalary = value; }
        }

        public Employee()
        {
           
        }
        //Declaring Method that Calculates Employee Allowances
        public decimal employeeAllowanceCal(decimal hra, decimal dAllowance, decimal cAllowance)
        {
            totalAllowances = hra + dAllowance + cAllowance;
            return totalAllowances;
        }

        //Declaring Method that Calculates Employee Deductions
        public decimal employeeDeductionCal(decimal pf, decimal tax)
        {
            totalDeductions = pf + tax;
            return totalDeductions;
        }


        //Calculates NetSalary of the Employee and Displays to the Console

        public string employeeSalaryCal(decimal eAllowance, decimal eDeductions)
        {
            decimal netSalary = basicSalary + eAllowance - eDeductions;
            return $"The Total Salary of the Employee {employeeName} after adding Allowances of {eAllowance} and Removing Detuctions of {eDeductions} is {netSalary}" ;
        }


    }
}
