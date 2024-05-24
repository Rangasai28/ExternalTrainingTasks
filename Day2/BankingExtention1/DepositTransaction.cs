using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingExtention1
{
    // Class for representing a deposit transaction
    public class DepositTransaction
    {
        // Fields to store transaction information
        Account _account; 
        decimal _amount; 
        bool _executed = false; 
        bool _success = false; 
        bool _reversed = false; 

        // Property to get whether the transaction has been executed
        public bool Executed
        {
            get { return _executed; }
        }

        // Property to get whether the transaction was successful
        public bool Success
        {
            get { return _success; }
        }

        // Property to get whether the transaction has been reversed
        public bool Reversed
        {
            get { return _reversed; }
        }

        // Constructor for DepositTransaction
        public DepositTransaction(Account account, decimal amount)
        {
            _account = account;
            _amount = amount;
        }

        // Method to print the transaction details
        public void print()
        {

            if (!Success)
            {
                Console.WriteLine("Transaction is Failed");
                Console.WriteLine("Check the Amount You have Entered");
                Console.WriteLine();
            }
            else
            {

                Console.WriteLine("The Transaction is Successful ");
                Console.WriteLine($"The Amount {_amount} is deposited into {_account.name} account and the available balance is {_account.balance}");
                Console.WriteLine();
            }
        }

        // Method to execute the deposit transaction
        public void Execute()
        {

            if (_executed)
            {
                throw new Exception("Cannot Execute This Transaction as it has already executed");
            }

            _executed = true;

            _success = _account.Deposit(_amount);

        }

        // Method to reverse the transaction
        public void Rollback()
        {

            if (!Executed)
            {
                throw new Exception("The Transaction is already executed");
            }

            if (Reversed)
            {
                throw new Exception("Cannot Execute This Transaction as it has already reversed");
            }

            if (Executed && !Reversed)
            {

                _account.Withdraw(_amount);
                _reversed = true;
            }
        }



    }
}
