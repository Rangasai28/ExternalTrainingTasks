﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    public class TransferTransaction
    {
        // Fields to store transaction information
        Account withdrawAccount;
        Account depositAccount;
        WithdrawTransaction objWithdraw;
        DepositTransaction objDeposit;
        decimal amount;
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

        // Constructor for TransferTransaction
        public TransferTransaction(Account firstaccount, Account secondAccount, decimal amount)
        {
            withdrawAccount = firstaccount;
            depositAccount = secondAccount;
            this.amount = amount;

            objWithdraw = new WithdrawTransaction(withdrawAccount, this.amount);
            objDeposit = new DepositTransaction(depositAccount, this.amount);
        }


        // Method to print the transaction details
        public void print()
        {
            if (Success)
            {
                
                Console.WriteLine("The Transaction is Successful ");

                Console.WriteLine($"The Amount {amount} is Transferred from {withdrawAccount.name} account to the {depositAccount.name} Account");
                Console.WriteLine();
                Console.WriteLine($"The Amount In {withdrawAccount.name} Account = {withdrawAccount.balance}");
                Console.WriteLine();
                Console.WriteLine($"The Amount In {depositAccount.name} Account = {depositAccount.balance}");
                Console.WriteLine();
                
            }
            else
            {
                Console.WriteLine("Transaction is Failed");
            }

        }






        // Method to execute the transfer transaction
        public void Execute()
        {

            if (Executed)
            {
                throw new Exception("Cannot Execute This Transaction as it has already executed");
            }

            _executed = true;
            objWithdraw.Execute();
            if (objWithdraw.Success)
            {
                objDeposit.Execute();
                if (objDeposit.Success)
                {
                    _success = true;
                }
                else
                {
                    objWithdraw.Rollback();
                }


            }


        }

        // Method to reverse the transaction
        public void Rollback()
        {

            if (!Executed)
            {
                throw new Exception("The Transaction is not Executed ");
            }

            if (Reversed)
            {
                throw new Exception("Cannot Execute This Transaction as it has already reversed");
            }

            _reversed = true;

            if (objWithdraw.Success)
            {
                objWithdraw.Rollback();
            }
            if (objDeposit.Success)
            {
                objDeposit.Rollback();
            }
        }
    }
}
