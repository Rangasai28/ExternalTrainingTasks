using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOProductCRUD
{
    internal class InputOutput
    {
        static ProductOperations productOperations = new ProductOperations();

        public static void AddProduct()
        {
            Product product = new Product();

            Console.WriteLine("Enter  Product Details");
            Console.Write("Enter Product Id:");
            product.Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Product Name:");
            product.Name = Console.ReadLine();

            Console.Write("Enter Product Description:");
            product.Description = Console.ReadLine();

            Console.Write("Enter Product Price:");
            product.Price = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Product  Quantity:");
            product.Quantity = Convert.ToInt32(Console.ReadLine());

            string sqlText = $"INSERT INTO PRODUCT VALUES({product.Id},'{product.Name}','{product.Description}',{product.Price},{product.Quantity})";

            Console.WriteLine(productOperations.Modify(sqlText));

        }

        public static void DeleteProduct()
        {

            Console.Write("Enter PRODUCT ID:");
            int id = Convert.ToInt32(Console.ReadLine());

            string sqlText = $"DELETE FROM PRODUCT WHERE ID = {id}";
            Console.WriteLine(productOperations.Modify(sqlText));
        }

        public static void UpdateProduct()
        {
            Product newproduct = new Product();

            Console.Write("Enter PRODUCT ID:");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter New Product Name:");
            newproduct.Name = Console.ReadLine();

            Console.Write("Enter New Product Description:");
            newproduct.Description = Console.ReadLine();

            Console.Write("Enter New Product Price:");
            newproduct.Price = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter New Product  Quantity:");
            newproduct.Quantity = Convert.ToInt32(Console.ReadLine());

            string sqlText = $"UPDATE PRODUCT SET   PNAME = '{newproduct.Name}' ,PDESCRIPTION = '{newproduct.Description}',PRICE = {newproduct.Price},QUANTITY = {newproduct.Quantity} WHERE ID = {id}";
            Console.WriteLine(productOperations.Modify(sqlText));
        }

        public static void getDetailsOfProduct()
        {
            Console.Write("Enter PRODUCT ID:");
            int id = Convert.ToInt32(Console.ReadLine());

            string sqlText = $"SELECT * FROM PRODUCT WHERE ID = {id}";
            Console.WriteLine(productOperations.getAllProducts(sqlText));

        }

        public static void getAllProducts()
        {
            string sqlText = $"SELECT * FROM PRODUCT";
            Console.WriteLine(productOperations.getAllProducts(sqlText));
        }
    }
}
