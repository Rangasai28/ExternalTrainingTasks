using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    public interface IAccount
    {
        string Name { get; }
        decimal Balance { get; }

        decimal WithdrawLimit {  get; }

        bool Withdraw(decimal amount);

        bool Deposit(decimal amount);

        string getDetails();
    }

    // Class for representing a bank account
    public abstract class Account : IAccount
    {
        // Fields to store account information

        public string Name { get; set; }
        public decimal Balance { get; set; }

        public decimal WithdrawLimit{ get; set; }


        // Method to print the balance of the account
        public abstract string getDetails();


        // Method to withdraw money from the account
        public abstract bool Withdraw(decimal withdrawAmount);
       

        // Method to deposit money into the account
        public bool Deposit(decimal depositAmount)
        {
            
                if (depositAmount > 0)
                {

                    Balance += depositAmount;

                    return true;
                }
                return false;
            
        }
    }
}
