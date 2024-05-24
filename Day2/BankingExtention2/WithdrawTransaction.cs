using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingExtention2
{
    public class WithdrawTransaction : Transaction
    {
        // Fields to store transaction information
        Account _account;
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

        // Constructor for WithdrawTransaction
        public WithdrawTransaction(Account account, decimal amount):base(amount)
        {
            _account = account;
        }

        // Method to execute the withdrawal transaction
        public override void Execute()
        {
            base.Execute();

            if (_executed)
            {
                throw new Exception("Cannot Execute This Transaction as it has already executed");
            }

            _executed = true;

            _success = _account.Withdraw(_amount);
        }

        // Method to reverse the transaction
        public override void Rollback()
        {
            base.Rollback();
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

                _account.Deposit(_amount);
                _reversed = true;
            }

        }

        // Method That Desplays the Withdraw transaction details
        public override void print()
        {

            if (!Success)
            {
                Console.WriteLine("WithDraw Transaction is Failed");
                Console.WriteLine("Check the Amount You have Entered");
                Console.WriteLine();
            }
            else
            {

                Console.WriteLine("The WithDraw Transaction is Successful ");
                Console.WriteLine($"The Amount {_amount} is withdrawn from {_account.name} account ");
                Console.WriteLine($"the available balance is {_account.balance}");
                Console.WriteLine();
            }


        }
    }
}
