using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOCRUDEMPLOYEE
{
    public enum MenuOption
    {
        Add = 1,
        Delete,
        Update,
        Print,
        AllEmployees,
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
                        InputOutput.AddEmp();
                        break;
                    case MenuOption.Delete:
                        InputOutput.DeleteEmp();
                        break;
                    case MenuOption.Update:
                        InputOutput.UpdateEmp();
                        break;
                    case MenuOption.Print:
                        InputOutput.getDetailsOfEmployee();
                        break;
                    case MenuOption.AllEmployees:
                        InputOutput.getAllEmployees();
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
