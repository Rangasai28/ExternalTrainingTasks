using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOProductCRUDExtention
{
    
        public enum MenuOption
        {
            Add = 1,
            Delete,
            Update,
            Print,
            AllProducts,
            Quit
        }
        internal class Menu
        {
            public void readUserOption()
            {
                MenuOption uoption = ReadUserOption();
                do
                {

                    switch (uoption)
                    {
                        case MenuOption.Add:
                            InputOutput.AddProduct();
                            break;
                        case MenuOption.Delete:
                            InputOutput.DeleteProduct();
                            break;
                        case MenuOption.Update:
                            InputOutput.UpdateProduct();
                            break;
                        case MenuOption.Print:
                            InputOutput.getDetailsOfProduct();
                            break;
                        case MenuOption.AllProducts:
                            InputOutput.getAllProducts();
                            break;
                        case MenuOption.Quit:
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
            public static MenuOption ReadUserOption()
            {

                MenuOption option = MenuOption.Add;


                do
                {
                    Console.WriteLine((int)option + " " + option);

                    option++;
                }
                while (option <= MenuOption.Quit);
                Console.WriteLine();
                Console.Write("Select Option From the Above Menu :");
                int userOption = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                return (MenuOption)userOption;

            }
        }
    
}
