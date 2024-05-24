using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalaRanga_CSharp101
{
    interface IAccount
    {
        string Name { get; }
        decimal Balance { get; }

        string Deposit(decimal amount);

        string Withdraw(decimal amount);

        string Print();
    }
    internal abstract class Account : IAccount
    {
        protected string? _name;

        protected decimal _balance;
        public string Name
        {
            get { return _name; }
        }

        public decimal Balance
        {
            get { return _balance; }
        }

        public abstract string Deposit(decimal amount);

        public abstract string Withdraw(decimal amount);

        public abstract string Print();

    }
}
