using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingExtention1
{
    // Class for representing a bank account
    public class Account
    {
        // Fields to store account information
        string _name;
        decimal _balance;

        // Constructor for creating an account
        public Account(string Name, decimal balance)
        {
            _name = Name;
            _balance = balance;
        }

        // Property to get the name of the account holder
        public string name
        {
            get
            {
                return _name;
            }
        }

        // Property to get the balance of the account
        public decimal balance
        {
            get
            {
                return _balance;
            }
        }

        // Method to print the balance of the account
        public string getBalance()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Account Holder Name = {0}{1}", name, Environment.NewLine);
            sb.AppendFormat("Available Balance = {0}{1}", balance, Environment.NewLine);
            return sb.ToString();
        }

        // Method to withdraw money from the account
        public bool Withdraw(decimal withdrawAmount)
        {

            if (withdrawAmount > 0 && withdrawAmount <= _balance)
            {
                _balance -= withdrawAmount;

                return true;
            }
            return false;




        }

        // Method to deposit money into the account
        public bool Deposit(decimal depositAmount)
        {

            if (depositAmount > 0)
            {

                _balance += depositAmount;

                return true;
            }
            return false;

        }
    }
}
