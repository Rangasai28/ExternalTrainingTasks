using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    class SavingsAccount : Account
    {
        public decimal InterestRate { get; set; }

        public SavingsAccount(string name,decimal balance, decimal interestRate,decimal withdrawLimit)
        {
            Name = name;
            Balance = balance;
            InterestRate = interestRate;
            WithdrawLimit = withdrawLimit;
        }
        public decimal calculateIntrest()
        {
            return Balance * InterestRate;
        }

        public override string getDetails()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Account Holder Name = {0}{1}", Name, Environment.NewLine);
            sb.AppendFormat("Available Balance = {0}{1}", Balance, Environment.NewLine);
            sb.AppendFormat("InterestRate = {0}{1}", calculateIntrest(), Environment.NewLine);
            sb.AppendFormat("WithdrawLimit = {0}{1}",WithdrawLimit, Environment.NewLine);
            return sb.ToString();
        }

        public override bool Withdraw(decimal withdrawAmount)
        {
            if (withdrawAmount > 0 && withdrawAmount <= Balance)
            {
                Balance -= withdrawAmount;

                return true;
            }
            return false;

        }
    }
}
