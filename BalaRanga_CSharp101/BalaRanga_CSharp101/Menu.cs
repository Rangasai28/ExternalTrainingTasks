using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalaRanga_CSharp101
{
    enum AccountMenu
    {
        saving =1,
        FD,
        Quit
    }
    public enum MenuOption
    {
        NewAccount = 1,
        Withdraw,
        Deposit,
        PrintBalance,
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
                    case MenuOption.NewAccount:
                        DoMethods.CreateNewAccount();
                        break;
                    case MenuOption.Withdraw:
                        DoMethods.DoWithdraw();
                        break;
                    case MenuOption.Deposit:
                        DoMethods.DoDeposit();
                        break;
                    //case MenuOption.Transfer:
                    //    DoTransfer(account);
                    //    break;
                    case MenuOption.PrintBalance:
                        DoMethods.DoPrint();
                        break;
                    case MenuOption.Quit:
                        break;
                    default:
                        Console.WriteLine(" Please Enter valid Input");
                        break;
                }
                if (Convert.ToInt32(uoption) == 5)
                {

                    break;
                }
                uoption = ReadUserOption();
            }
            while (Convert.ToInt32(uoption) != 5);
            Console.WriteLine("Transaction Ended");

        }

        //Method That Returns User Option
        public static  MenuOption ReadUserOption()
        {
            MenuOption option = MenuOption.NewAccount;


            // Iterate over the enum values using a do-while loop
            do
            {
                Console.WriteLine((int)option + " " + option);
                // Increment the enum variable to the next value
                option++;
            }
            while (option <= MenuOption.Quit);
            Console.Write("Select One of the Option From the Above Menu:");
            int userOption = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            // Console.WriteLine(userOption);
            return (MenuOption)userOption;


        }

        public static AccountMenu SelectAccount()
        {
            Console.WriteLine("1" + " " + AccountMenu.saving);
            Console.WriteLine("2" + " " + AccountMenu.FD);
            Console.Write("Select Type fo the Account To Create From the Above Menu:");

           
            int userOption = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            // Console.WriteLine(userOption);
            return (AccountMenu)userOption;
        }

        
    }
}
