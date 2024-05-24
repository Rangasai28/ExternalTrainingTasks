using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    // Class for representing a deposit transaction
    public class DepositTransaction
    {
        // Fields to store transaction information
        Account _account; // The account into which the amount is deposited
        decimal _amount; // The amount to be deposited
        bool _executed = false; // Flag indicating whether the transaction has been executed
        bool _success = false; // Flag indicating whether the transaction was successful
        bool _reversed = false; // Flag indicating whether the transaction has been reversed

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
        public string print()
        {
            
            if (Success)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("The Transaction is Successful {0}", Environment.NewLine);

                sb.Append($"The Amount {_amount} is deposited into {_account.name} account and the available balance is {_account.balance}");
                return sb.ToString();
            }
           
            else
            {

                StringBuilder sb = new StringBuilder();
                sb.Append("Transaction is Failed");
                sb.Append("\n");
                sb.Append("Check the Amount You have Entered");
                sb.Append("\n");
                return sb.ToString();
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

