using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    public delegate bool Transaction( decimal amount);
    public class delegates
    {
        static void Main(string[] args)
        {
            Account firstaccount = new Account("Bala", 30000);
            Account secondaccount  = new Account("Sai",40000);
            
            delegates obj = new delegates();
            Transaction withdrawtra, deposittra;

            withdrawtra = new Transaction(firstaccount.Withdraw);
            deposittra = new Transaction(secondaccount.Deposit);

            

            Console.WriteLine(withdrawtra(20000) ? firstaccount.getBalance() : "Transaction Failed");
            Console.WriteLine(deposittra(-20000) ? secondaccount.getBalance() : "Transaction Failed");

            





        }
    }

   
}
