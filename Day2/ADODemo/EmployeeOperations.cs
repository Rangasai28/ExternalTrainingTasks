using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace ADODemo
{
     class EmployeeOperations
     {
        SqlConnection? connect;
        SqlCommand? command;
        SqlDataReader? reader;
        
        public string Add(String sqlText)
        {
            try
            {
                connect = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = EmployeeDB; Integrated Security = True; Pooling = False");
                connect.Open();
                command = new SqlCommand(sqlText, connect);
                int effectedRows = command.ExecuteNonQuery();
                return ($"{effectedRows}  Rows Got Effected");

            }
            catch(SqlException ex)
            {
                return ex.Message;
            }
           
        }

        public string Delete(String sqlText)
        {
            try
            {
                connect = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = EmployeeDB; Integrated Security = True; Pooling = False");
                connect.Open();
                command = new SqlCommand(sqlText, connect);
                int effectedRows = command.ExecuteNonQuery();
                return ($"{effectedRows}  Rows Got Effected");
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
        }

        public string getEmployee(String sqlText)
        {
            try
            {
                connect = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = EmployeeDB; Integrated Security = True; Pooling = False");
                connect.Open();
                command = new SqlCommand(sqlText, connect);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("Employee Id is: {0}{1}", reader[0].ToString(), Environment.NewLine);
                    sb.AppendFormat("Employee Name is: {0}{1}", reader[1].ToString(), Environment.NewLine);
                    sb.AppendFormat("Department ID  is: {0}{1}", reader[2].ToString(), Environment.NewLine);
                    sb.AppendFormat("Contact Number is: {0}{1}", reader[3].ToString(), Environment.NewLine);
                    reader.Close();
                    return sb.ToString();
                  
                }
                else
                {
                    return "No Record Found";
                }
                
            }
            catch(SqlException ex)
            {
                return ex.Message;
            }
        }

        public string getAllEmployees(String sqlText)
        {
            try
            {
                connect = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = EmployeeDB; Integrated Security = True; Pooling = False");
                connect.Open();
                command = new SqlCommand(sqlText, connect);
                reader = command.ExecuteReader();
                StringBuilder sb = new StringBuilder();
                while (reader.Read())
                {
                    sb.AppendFormat("Employee Id is: {0}{1}", reader[0].ToString(), Environment.NewLine);
                    sb.AppendFormat("Employee Name is: {0}{1}", reader[1].ToString(), Environment.NewLine);
                    sb.AppendFormat("Department ID  is: {0}{1}", reader[2].ToString(), Environment.NewLine);
                    sb.AppendFormat("Contact Number is: {0}{1}", reader[3].ToString(), Environment.NewLine);
                }
                reader.Close();
                return sb.ToString();
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
        }
     }

   
}
