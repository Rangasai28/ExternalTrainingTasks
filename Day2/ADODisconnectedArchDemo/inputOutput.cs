using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Channels;

namespace ADODisconnectedArchDemo
{
    internal class inputOutput
    {
        static DatasetHelper datasetHelper = new DatasetHelper();
        static DataSet data = datasetHelper.fetchData();
        static DataTable productsTable = data.Tables[0];
        public static void AddProduct()
        {
            DataRow newRow = productsTable.NewRow();
            

            Console.WriteLine("Enter  Product Details");
            Console.Write("Enter Product Id:");
            newRow[0] = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Product Name:");
            newRow[1] = Console.ReadLine();

            Console.Write("Enter Product Description:");
            newRow[2] = Console.ReadLine();

            Console.Write("Enter Product Price:");
            newRow[3] = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Product  Quantity:");
            newRow[4] = Convert.ToInt32(Console.ReadLine());

            data.Tables[0].Rows.Add(newRow);
            datasetHelper.modifyData();
            Console.WriteLine("Addeded Successfully");
        }

        public static void DeleteProduct()
        {

            Console.Write("Enter PRODUCT ID:");
            int ID = Convert.ToInt32(Console.ReadLine());
            try
            {
               // DataRow deleteRow = productsTable.Select($"ID = {ID}")[0];
                DataRow deleteRow = productsTable.Rows.Find(ID);

                if (deleteRow != null)
                {
                    deleteRow.Delete();
                    datasetHelper.modifyData();
                    Console.WriteLine("Deleted Successfully");
                }
                else
                {
                    Console.WriteLine("Row is Not Found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            

            
        }

        public static void UpdateProduct()
        {
            
            Console.Write("Enter PRODUCT ID:");
            int ID = Convert.ToInt32(Console.ReadLine());
            try
            {
                DataRow updateRow = productsTable.Select($"ID = {ID}")[0];
                //DataRow updateRow = productsTable.Rows.Find(ID);
                if (updateRow != null)
                {
                    Console.Write("Enter New Product Name:");
                    updateRow[1] = Console.ReadLine();

                    Console.Write("Enter New Product Description:");
                    updateRow[2] = Console.ReadLine();

                    Console.Write("Enter New Product Price:");
                    updateRow[3] = Convert.ToDecimal(Console.ReadLine());   

                    Console.Write("Enter New Product  Quantity:");
                    updateRow[4] = Convert.ToInt32(Console.ReadLine());

                    datasetHelper.modifyData();

                    Console.WriteLine("Updated Successfully");

                }
                else
                {
                    Console.WriteLine("Row is Not Found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void getDetailsOfProduct()
        {
            Console.Write("Enter PRODUCT ID:");
            int ID = Convert.ToInt32(Console.ReadLine());

            try
            {
                DataRow getRow = productsTable.Select($"ID = {ID}")[0];

                if (getRow != null)
                {
                    Console.WriteLine($"ID: {getRow[0]}, PName: {getRow[1]}, DESCRIPTION: {getRow[2]}, Price: {getRow[3]}, Quantity: {getRow[4]}");

                }
                else
                {
                    Console.WriteLine("Row is Not Found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            

        }

        public static void getAllProducts()
        {
           foreach(DataRow row in productsTable.Rows)
           {
                Console.WriteLine($"ID: {row[0]}, PName: {row[2]}, PDESCRIPTION: {row[2]}, Price: {row[3]}, Quantity: {row[4]}");
                Console.WriteLine();
           }
            
        }

    }
}
