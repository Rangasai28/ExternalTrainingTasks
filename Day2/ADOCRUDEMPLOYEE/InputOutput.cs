using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOCRUDEMPLOYEE
{
    internal class InputOutput
    {
        static EmployeeOperations employeeOperations = new EmployeeOperations();
        static DataSet dataset = employeeOperations.getData();
        static DataTable employeeTable = dataset.Tables[0];
        public static void AddEmp()
        {
           DataRow newRow = employeeTable.NewRow();

            Console.WriteLine("Enter  Employee Details");

            Console.Write("Enter Employee Id:");
            newRow[0]  = Convert.ToInt32(Console.ReadLine());


            Console.Write("Enter Employee Name:");
            newRow[1] = Console.ReadLine();

            Console.Write("Enter Employee Contact Number:");
            newRow[2] = Console.ReadLine();

            Console.Write("Enter Employee DepartmentId:");
            newRow[3] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            employeeTable.Rows.Add(newRow);

            employeeOperations.modifyData();

            Console.WriteLine("Added Successfully");

        }

        public static void DeleteEmp()
        {

            Console.Write("Enter Employee ID:");
            int id = Convert.ToInt32(Console.ReadLine());

            

            try
            {
                DataRow delRow = employeeTable.Select($"ID = {id}")[0];
                if (delRow != null)
                {
                    delRow.Delete();
                    employeeOperations.modifyData();
                    Console.WriteLine("Successfully Deleted");
                }
                else
                {
                    Console.WriteLine("Record is not Found");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void UpdateEmp()
        {
            Employee newemployee = new Employee();
            Console.Write("Enter Employee Id:");
            int Id = Convert.ToInt32(Console.ReadLine());
            try
            {
                DataRow updRow = employeeTable.Select($"ID = {Id}")[0];
                if (updRow != null)
                {
                    Console.Write("Enter NEW Employee Name:");
                    updRow[1] = Console.ReadLine();

                    Console.Write("Enter NEW Employee Contact Number:");
                    updRow[2] = Console.ReadLine();

                    Console.Write("Enter NEW Employee DepartmentId:");
                    updRow[3] = Convert.ToInt32(Console.ReadLine());

                    employeeOperations.modifyData();
                    Console.WriteLine("Successfully Updated");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void getDetailsOfEmployee()
        {
            Console.Write("Enter Employee ID:");
            int id = Convert.ToInt32(Console.ReadLine());

            try
            {
                DataRow getRow = employeeTable.Select($"ID = {id}")[0];
                if (getRow != null)
                {
                    Console.WriteLine("Employee Id is: {0}", getRow[0]);
                    Console.WriteLine("Employee Name is: {0}",getRow[1]);
                    Console.WriteLine("Department ID  is: {0}", getRow[2]);
                    Console.WriteLine("Contact Number is: {0}", getRow[3]);
                    Console.WriteLine();
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            


        }

        public static void getAllEmployees()
        {
            foreach (DataRow row in employeeTable.Rows)
            {
                Console.WriteLine("Employee Id is: {0}", row[0]);
                Console.WriteLine("Employee Name is: {0}", row[1]);
                Console.WriteLine("Department ID  is: {0}", row[2]);
                Console.WriteLine("Contact Number is: {0}", row[3]);
                Console.WriteLine(5);
            }
        }
    }
}

