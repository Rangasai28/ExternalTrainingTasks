using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    internal class CurrentAccount:Account
    {
       
        public decimal OverdraftLimit {  get; set; }

        public CurrentAccount(string name, decimal balance, decimal withdrawLimit, decimal overdraftLimit)
        {
            Name = name;
            Balance = balance;
            WithdrawLimit = withdrawLimit;
            OverdraftLimit = overdraftLimit;
        }
        public override string getDetails()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Account Holder Name = {0}{1}", Name, Environment.NewLine);
            sb.AppendFormat("Available Balance = {0}{1}", Balance, Environment.NewLine);
            sb.AppendFormat("WithdrawLimit = {0}{1}", WithdrawLimit, Environment.NewLine);
            sb.AppendFormat("OverdraftLimit = {0}{1}",OverdraftLimit, Environment.NewLine);
            return sb.ToString();
        }

        public override bool Withdraw(decimal withdrawAmount)
        {
           
            if (withdrawAmount > 0 && withdrawAmount <= Balance && (Balance + OverdraftLimit) >= withdrawAmount)
            {
                Balance -= withdrawAmount;

                return true;
            }
            return false;
        }
    }
}
