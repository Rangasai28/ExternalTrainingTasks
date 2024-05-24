using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingExtention2
{
    public class TransferTransaction:Transaction
    {
        // Fields to store transaction information
        Account withdrawAccount;
        Account depositAccount;
        WithdrawTransaction objWithdraw;
        DepositTransaction objDeposit;
       
        bool _executed = false;
        bool _success = false;
        bool _reversed = false;

        // Executed ReadOnly Property
        public new bool Executed
        {
            get { return _executed; }
        }

        // Successful ReadOnly Property
        public override bool Success
        {
            get { return _success; }
        }

        // Reversed ReadOnly Property
        public new bool Reversed
        {
            get { return _reversed; }
        }

        // Constructor for TransferTransaction
        public TransferTransaction(Account firstaccount, Account secondAccount, decimal amount):base(amount)
        {
            withdrawAccount = firstaccount;
            depositAccount = secondAccount;
            

            objWithdraw = new WithdrawTransaction(withdrawAccount, amount);
            objDeposit = new DepositTransaction(depositAccount, amount);
        }


        // Method to print the transaction details
        public override void print()
        {
            if (Success)
            {

                Console.WriteLine("The Transfer  Transaction is Successful ");

                Console.WriteLine($"The Amount {_amount} is Transferred from {withdrawAccount.name} account to the {depositAccount.name} Account");
                Console.WriteLine($"The Amount In {withdrawAccount.name} Account = {withdrawAccount.balance}");
                Console.WriteLine($"The Amount In {depositAccount.name} Account = {depositAccount.balance}");
                Console.WriteLine();

            }
            else
            {
                Console.WriteLine("Transaction is Failed");
            }

        }






        // Method to execute the transfer transaction
        public override void Execute()
        {
            base.Execute();
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
        public override void Rollback()
        {
            base.Rollback();
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
