using System;
using System.Xml.Linq;
using static ProductCrud.Program;

namespace ProductCrud
{
    internal class Program
    {
        public enum menuOptions
        {
            AddProduct = 1,
            DeleteProduct,
            UpdateProduct,
            DisplayProduct,
            ListofProducts,
            Exit
        }
        static void Main(string[] args)
        {
           

            
            menuOptions uoption = Program.ReadUserOption();

            do
            {

                switch (uoption)
                {
                    case menuOptions.AddProduct:
                        doOperations.addProduct();
                        break;
                    case menuOptions.DeleteProduct:
                        doOperations.deleteProduct();
                        break;
                    case menuOptions.UpdateProduct:
                        doOperations.updateProduct();
                        break;
                    case menuOptions.DisplayProduct:
                        doOperations.displayProduct();
                        break;
                    case menuOptions.ListofProducts:
                        doOperations.displayProducts();
                        break;
                    case menuOptions.Exit:
                        break;
                    default:
                        Console.WriteLine(" Please Enter valid Input");
                        break;
                }
                if (Convert.ToInt32(uoption) == 6)
                {
                    break;
                }
                uoption = ReadUserOption();
            }
            while (Convert.ToInt32(uoption) != 6);
            Console.WriteLine();

           

        }
        public static menuOptions ReadUserOption()
        {
            menuOptions option = menuOptions.AddProduct;


            do
            {
                Console.WriteLine((int)option + " " + option);

                option++;
            }
            while (option <= menuOptions.Exit);
            Console.WriteLine();
            Console.Write("Select Option From the Above Menu :");
            int userOption = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            return (menuOptions)userOption;

        }

      


    }
}
