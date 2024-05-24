using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADODemo
{
     class InputOutput
     {
        static  EmployeeOperations employeeOperations = new EmployeeOperations();
       
        public static void AddEmp()
        {
            Employee employee = new Employee();

            Console.WriteLine("Enter  Employee Details");
            Console.Write("Enter Employee Id:");
            employee.Id = Convert.ToInt32(Console.ReadLine());

            

            Console.Write("Enter Employee Name:");
            employee.Name = Console.ReadLine();

            Console.Write("Enter Employee Contact Number:");
            employee.Number = Console.ReadLine();

            Console.Write("Enter Employee DepartmentId:");
            employee.DepartmentId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            string sqlText = $"INSERT INTO EMPLOYEE VALUES({employee.Id},'{employee.Name}',{employee.DepartmentId},'{employee.Number}')";

            Console.WriteLine(employeeOperations.Add(sqlText));
           
        }

        public static void DeleteEmp()
        {

            Console.Write("Enter Employee ID:");
            int id = Convert.ToInt32(Console.ReadLine());

            string sqlText = $"DELETE FROM EMPLOYEE WHERE ID = {id}";
            Console.WriteLine(employeeOperations.Delete(sqlText));
        }

        public static void UpdateEmp()
        {
            Employee newemployee = new Employee();
            Console.Write("Enter Employee Id:");
            int Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter NEW Employee Name:");
            newemployee.Name = Console.ReadLine();

            Console.Write("Enter NEW Employee Contact Number:");
            newemployee.Number = Console.ReadLine();

            Console.Write("Enter NEW Employee DepartmentId:");
            newemployee.DepartmentId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            string sqlText = $"UPDATE EMPLOYEE SET EName = '{newemployee.Name}',DepartmentID = {newemployee.DepartmentId},NUMBER = '{newemployee.Number}' WHERE ID = {Id}";

            Console.WriteLine(employeeOperations.Add(sqlText));
        }

        public static void getDetailsOfEmployee()
        {
            Console.Write("Enter Employee ID:");
            int id = Convert.ToInt32(Console.ReadLine());

            string sqlText = $"SELECT * FROM EMPLOYEE WHERE ID = {id}";
            Console.WriteLine(employeeOperations.getEmployee(sqlText));

        }

        public static void getAllEmployees()
        {
            string sqlText = $"SELECT * FROM EMPLOYEE";
            Console.WriteLine(employeeOperations.getAllEmployees(sqlText));
        }
     }
}
