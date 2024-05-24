using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    internal class Utility
    { 
        public static string ReadStringInputs()
        {
            string result;
            do
            {
                Console.Write("Enter the String Input:");
                result = Console.ReadLine();
                if (string.IsNullOrEmpty(result))
                {
                    Console.WriteLine("Invalid Input ");
                    
                }
               
            }
            while(string.IsNullOrEmpty(result));
            return result;
        }

        static int ReadIntegerInput()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Invalid input. Please enter an integer:");
            }
            return result;
        }
        static void Main(string[] args)
        {
            //string n = ReadStringInputs();
            //Console.WriteLine(n);

            int b = ReadIntegerInput();
            Console.WriteLine(b);
            //List<Account> accounts = new List<Account>();
            //accounts.Add(new Account("Bala", 30000));
            //accounts.Add(new Account("Ranga", 20000));
            //accounts.Add(new Account("Sai", 10000));



        }


    }

}
