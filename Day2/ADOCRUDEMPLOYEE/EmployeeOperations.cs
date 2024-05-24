using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace ADOCRUDEMPLOYEE
{
    internal class EmployeeOperations
    {

        SqlConnection? connect = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = EmployeeDB; Integrated Security = True; Pooling = False");
        DataSet dataset = new DataSet();
        SqlDataAdapter adapter;
        SqlCommandBuilder? command;




        public DataSet getData()
        {
            string query = "SELECT * FROM Employee";
            adapter = new SqlDataAdapter(query, connect);
            command = new SqlCommandBuilder(adapter);
            adapter.Fill(dataset);
            return dataset;
        }



        public void modifyData()
        {
            adapter.Update(dataset);
        }


    }
}