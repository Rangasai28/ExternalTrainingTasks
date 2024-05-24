using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalaRanga_CSharp101
{
    
    internal class DoMethods
    {


        
        static XYZBank bank = new XYZBank();

        public static void CreateNewAccount()
        {
            Console.WriteLine();
            Console.WriteLine("Enter Account Holders Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Starting Balance:");
            decimal balance = Convert.ToDecimal(Console.ReadLine());

            Account account;
            Console.WriteLine();
            
            AccountMenu accountType = Menu.SelectAccount();
            if (accountType == AccountMenu.saving)
            {

                account = new SavingsAccount(name, balance);
                Console.WriteLine("Savings Account Got Created");
                bank.AddAccount(account);
                Console.WriteLine();
            }
            else
            {
                account = new FDAccount(name, balance);
                Console.WriteLine("FDAccount Got Created");
                bank.AddAccount(account);
                Console.WriteLine();
            }
        }
        public static void DoWithdraw()
        {
            Account account = FindAccount(bank);
            if (account == null) return;

            Console.WriteLine("Enter Amount to Withdraw");
            decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());


            Console.WriteLine(account.Withdraw(withdrawAmount));
            Console.WriteLine(account.Print());
            Console.WriteLine();
        }

        public static void DoDeposit()
        {
            Account account = FindAccount(bank);
            if (account == null) return;
            Console.WriteLine("Enter Amount to Deposit");
            decimal depositAmount = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine(account.Deposit(depositAmount));
            Console.WriteLine(account.Print());
            Console.WriteLine();
        }

        public static void DoPrint()
        {
            Account account = FindAccount(bank);
            if (account == null) return;
            Console.WriteLine(account.Print());
            Console.WriteLine();
        }

        private static Account FindAccount(XYZBank bank)
        {
            Console.Write("Enter Account Holders Name :");
            string name = Console.ReadLine();

            Account result = bank.GetAccount(name);
            if (result == null)
            {
                Console.WriteLine($"No Account is Found With the Specified Name : {name}");
                Console.WriteLine("Transaction Ended");
                Console.WriteLine();
            }
            return result;
        }
    }
}
