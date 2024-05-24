using System.Collections;
using static EmployeeCRUD.EmployeeOperations;

namespace EmployeeCRUD
{
    internal class Program
    {
        public static EmployeeOperations obj = new EmployeeOperations();
        public static ArrayList emp = obj.getEmployeeList();
        public enum MenuOptions
        {
            Add=1,
            Delete,
            Update,
            List,
            ListAll,
            Exit
        }

       
        public static void Main(string[] args)
        {
            
            MenuOptions uoption = Program.ReadUserOption();
            do
            {

                switch (uoption)
                {
                    case MenuOptions.Add:
                        Program.AddEmp();
                        break;
                    case MenuOptions.Delete:
                        Program.DeleteEmp();
                        break;
                    case MenuOptions.Update:
                        Program.UpdateEmp();
                        break;
                    case MenuOptions.List:
                        Program.getEmployeeDetails();
                        break;
                    case MenuOptions.ListAll:
                        Program.getListOfEmployess();
                        break;
                    case MenuOptions.Exit:

                        break;
                    default:
                        Console.WriteLine(" Please Enter valid Input");
                        break;
                }
                if (Convert.ToInt32(uoption) == 6)
                {
                    break;
                }
                uoption = Program.ReadUserOption();
            }
            while (Convert.ToInt32(uoption) != 6);
            Console.WriteLine();
        }

        public static MenuOptions ReadUserOption()
        {

            MenuOptions option = MenuOptions.Add;


            do
            {
                Console.WriteLine((int)option + " " + option);
               
                option++;
            }
            while (option <= MenuOptions.Exit);
            Console.WriteLine();
            Console.Write("Select Option From the Above Menu :");
            int userOption = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            return (MenuOptions)userOption;
            
        }


        
        //public static UpdateMenu ReadUpdateField()
        //{

        //    UpdateMenu option = UpdateMenu.Name;


            
        //    do
        //    {
        //        Console.WriteLine((int)option + " " + option);
               
        //        option++;
        //    }
        //    while (option <= UpdateMenu.Exit);
        //    Console.Write("Select Employee Field to be Edited from above Menu :");
        //    int userOption = Convert.ToInt32(Console.ReadLine());
            
           
        //    return (UpdateMenu)userOption;
        //}

        public static void AddEmp()
        {
            Employee employee = new Employee();

            Console.WriteLine("Enter  Employee Details");
            Console.Write("Enter Employee Id:");
            int id = Convert.ToInt32(Console.ReadLine());

            foreach (Employee e in obj.EmployeeList)
            {
                if (e.Id == id)
                {
                    Console.WriteLine("Already Exists Enter Another Id");
                    Program.AddEmp();
                }
            }

            Console.Write("Enter Employee Name:");
            employee.Name = Console.ReadLine();

            Console.Write("Enter Employee Contact Number:");
            employee.ContactNumber = Convert.ToInt64(Console.ReadLine());

            Console.Write("Enter Employee Salary:");
            employee.Salary = Convert.ToDecimal(Console.ReadLine());

           // Employee employee = new Employee(id,name,contactnumber,salary);


            obj.AddEmployee(employee);
            
            Console.WriteLine("Dettails are Added ");
            Console.WriteLine();
          // Console.WriteLine( obj.List(101));
        }

        public static void DeleteEmp()
        {
           

            Console.Write("Enter Employees ID To Delete:");
            int id = Convert.ToInt32(Console.ReadLine());
            
            int index = 0;
            foreach (Employee employee in emp)
            {
                if (employee.Id == id)
                {
                    index = emp.IndexOf(employee);

                }
            }
            obj.DeleteEmployee(index);
            
        }

        public static void UpdateEmp()
        {
            Employee newEmp = new Employee();

            Console.Write("Enter Employees ID To Update:");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Employee Name:");
            newEmp.Name = Console.ReadLine();

            Console.Write("Enter Employee Contact Number:");
            newEmp.ContactNumber = Convert.ToInt64(Console.ReadLine());

            Console.Write("Enter Employee Salary:");
            newEmp.Salary = Convert.ToDecimal(Console.ReadLine());

            obj.UpdateEmployee(newEmp, id);

        }

        public static void getEmployeeDetails()
        {
            Console.Write("Enter Id of the Employee To Get Details:");
            int id = Convert.ToInt32(Console.ReadLine());
            
            foreach (Employee element in emp)
            {
                if(element.Id == id)
                {
                    Console.WriteLine("Employee ID = {0}", element.Id);
                    Console.WriteLine("Employee Name = {0}", element.Name);
                    Console.WriteLine("Employee Contact number = {0}", element.ContactNumber);
                    Console.WriteLine("Employee Salary = {0}", element.Salary);
                }
               Console.WriteLine();

            }

        }

        public static void getListOfEmployess()
        {
            ArrayList emp = obj.getEmployeeList();
            foreach (Employee element in emp)
            {
                
                    Console.WriteLine("Employee ID = {0}", element.Id);
                    Console.WriteLine("Employee Name = {0}", element.Name);
                    Console.WriteLine("Employee Contact number = {0}", element.ContactNumber);
                    Console.WriteLine("Employee Salary = {0}", element.Salary);
                    Console.WriteLine();
            }
            Console.WriteLine();
        }

        
    }
}
