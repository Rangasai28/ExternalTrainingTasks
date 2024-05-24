using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    // Class for representing a withdrawal transaction
    public class WithdrawTransaction
    {
        // Fields to store transaction information
        Account _account;
        decimal _amount;
        bool _executed = false; 
        bool _success = false; 
        bool _reversed = false; 

        // Executed ReadOnly Property
        public bool Executed
        {
            get { return _executed; }
        }

        // Successful ReadOnly Property
        public bool Success
        {
            get { return _success; }
        }

        // Reversed ReadOnly Property
        public bool Reversed
        {
            get { return _reversed; }
        }

        // Constructor for WithdrawTransaction
        public WithdrawTransaction(Account account, decimal amount)
        {
            _account = account;
            _amount = amount;
        }

        // Method to execute the withdrawal transaction
        public void Execute()
        {
           
            if (_executed)
            {
                throw new Exception("Cannot Execute This Transaction as it has already executed");
            }
        
            _executed = true;
            
            _success = _account.Withdraw(_amount);
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
            
            if(Executed && !Reversed)
            {
                
                _account.Deposit(_amount);
                _reversed = true;
            }
            
        }

        // Method That Desplays the Withdraw transaction details
        public string print()
        {
            
            if (!Success )
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Transaction is Failed");
                sb.Append("\n");
                sb.Append("Check the Amount You have Entered");
                sb.Append("\n");
                return sb.ToString();
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("The Transaction is Successful {0}",Environment.NewLine);

                sb.AppendFormat($"The Amount {_amount} is withdrawn from {_account.name} account and the available balance is {_account.balance}");
                return sb.ToString();
            }

            
        }
    }
}
