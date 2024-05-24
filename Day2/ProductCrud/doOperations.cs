using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCrud
{
    public  class doOperations
    {
        static ProductOperations obj = new ProductOperations();
        static List<Product> product = obj.getProductList();
        public static void addProduct()
        {
            Product product = new Product();
            Console.WriteLine("Enter  Product Details");
            Console.Write("Product Id:");
            product.productId = Convert.ToInt32(Console.ReadLine());

            foreach (Product p in obj.productsList)
            {
                if (p.productId == product.productId)
                {
                    Console.WriteLine("Already Exists Enter Another Id");
                    addProduct();
                }
            }

            Console.Write("Product Name:");
            product.productName = Console.ReadLine();

            Console.Write("Product description:");
            product.productDescription = Console.ReadLine();

            Console.Write("Product Image URL:");
            product.productImage = Console.ReadLine();

            Console.Write("Product Price:");
            product.productPrice = Convert.ToDecimal(Console.ReadLine());



            obj.AddProduct(product);
            Console.WriteLine("Dettails are Added ");
            Console.WriteLine();

        }

        public static void deleteProduct()
        {
            Console.WriteLine("Enter The Id Of the Product");
            int id = Convert.ToInt32(Console.ReadLine());
            int index = 0;

            foreach (Product p in product)
            {
                if (p.productId == id)
                {
                    index = product.IndexOf(p);
                }
            }
            obj.DeleteProduct(index);
        }

        public static void updateProduct()
        {
            Product newProduct = new Product();
            Console.WriteLine("Enter  Product Id to Update:");

            int Id = Convert.ToInt32(Console.ReadLine());



            Console.Write("Product Name:");
            newProduct.productName = Console.ReadLine();

            Console.Write("Product description:");
            newProduct.productDescription = Console.ReadLine();

            Console.Write("Product Image URL:");
            newProduct.productImage = Console.ReadLine();

            Console.Write("Product Price:");
            newProduct.productPrice = Convert.ToDecimal(Console.ReadLine());



            obj.UpdateProduct(newProduct, Id);
            Console.WriteLine("Dettails are Added ");
            Console.WriteLine();
        }
        public static void displayProduct()
        {
            Console.Write("Enter Id of the Product:");
            int id = Convert.ToInt32(Console.ReadLine());



            foreach (Product p in product)
            {
                if (p.productId == id)
                {
                    Console.WriteLine("Product ID = {0}", p.productId);
                    Console.WriteLine("Product Name = {0}", p.productName);
                    Console.WriteLine("Product Description = {0}", p.productDescription);
                    Console.WriteLine("Product IMage URL = {0}", p.productImage);
                    Console.WriteLine("Product Price = {0}", p.productPrice);
                }
            }
        }

        public static void displayProducts()
        {
            foreach (Product p in product)
            {


                Console.WriteLine("Product ID = {0}", p.productId);
                Console.WriteLine("Product Name = {0}", p.productName);
                Console.WriteLine("Product Description = {0}", p.productDescription);
                Console.WriteLine("Product IMage URL = {0}", p.productImage);
                Console.WriteLine("Product Price = {0}", p.productPrice);
                Console.WriteLine();

            }
        }
    }
}
