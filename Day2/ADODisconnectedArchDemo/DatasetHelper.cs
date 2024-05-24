using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ADODisconnectedArchDemo
{
    internal class DatasetHelper
    {
        readonly SqlConnection? connect = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PRODUCTDB;Integrated Security=True;Pooling=False");
        readonly DataSet dataset = new DataSet();
        SqlDataAdapter? adapter;
        SqlCommandBuilder? command;
        //Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = PRODUCTDB; Integrated Security = True; Pooling=False;Encrypt=True;Trust Server Certificate=False
        public DataSet fetchData()
        {
            string query = "SELECT * FROM PRODUCT";
            adapter = new SqlDataAdapter(query, connect);
            adapter.MissingSchemaAction = MissingSchemaAction.Add;
            command = new SqlCommandBuilder(adapter);
            adapter.Fill(dataset);
            return dataset;
        }


        public void  modifyData()
        {
            adapter.Update(dataset);
        }
    }
}
