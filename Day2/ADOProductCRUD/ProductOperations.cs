using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ADOProductCRUD
{
    internal class ProductOperations
    {
        SqlConnection? connect = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PRODUCTDB;Integrated Security=True;Pooling=False");
        SqlCommand? command;
        SqlDataReader? reader;

        public string Modify(string sqlText)
        {
            try
            {
                
                connect.Open();
                command = new SqlCommand(sqlText, connect);
                int effectedRows = command.ExecuteNonQuery();
                connect.Close();
                return ($"{effectedRows}  Rows Got Effected");

            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
        }

        

        public string getAllProducts(string sqlText)
        {
            try
            {
                
                connect.Open();
                command = new SqlCommand(sqlText, connect);
                reader = command.ExecuteReader();
                StringBuilder sb = new StringBuilder();
                while (reader.Read())
                {
                    sb.AppendFormat("Product Id is: {0}{1}", reader[0].ToString(), Environment.NewLine);
                    sb.AppendFormat("Product Name is: {0}{1}", reader[1].ToString(), Environment.NewLine);
                    sb.AppendFormat("Product Description  is: {0}{1}", reader[2].ToString(), Environment.NewLine);
                    sb.AppendFormat("Product Price is: {0}{1}", reader[3].ToString(), Environment.NewLine);
                    sb.AppendFormat("Product Quantity is: {0}{1}", reader[4].ToString(), Environment.NewLine);
                    sb.AppendFormat(Environment.NewLine);
                }
                reader.Close();
                connect.Close();
                return sb.ToString();
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
        }
    }
}
