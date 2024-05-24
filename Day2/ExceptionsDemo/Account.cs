using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionDemo
{
    // Class for representing a bank account
    public class Account
    {
        // Fields to store account information
        string _name; // The name of the account holder
        decimal _balance; // The balance of the account

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
        public string printBalance()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Available Balance = {0}{1}", _balance, Environment.NewLine);
            return sb.ToString();
        }

        // Method to withdraw money from the account
        public bool Withdraw(decimal withdrawAmount)
        {

            if (balance < withdrawAmount || balance == 0 || withdrawAmount <= 0)
            {
                return false;
            }
            else
            {
                _balance -= withdrawAmount;
                return true;
            }
        }

        // Method to deposit money into the account
        public bool Deposit(decimal depositAmount)
        {

            if (depositAmount <= 0)
            {
                return false;
            }
            else
            {
                _balance += depositAmount;
                return true;
            }
        }
    }
}
