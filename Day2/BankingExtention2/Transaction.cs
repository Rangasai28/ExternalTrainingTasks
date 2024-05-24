using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingExtention2
{
    public abstract class Transaction
    {
        protected decimal _amount;

         bool _executed = false;

         bool _reversed = false;

         DateTime _dateStamp;

        public Transaction(decimal amount)
        {
            _amount = amount;
            
        }
        public decimal Amount
        {
            get
            {
                return _amount;
            }
        }
        public bool Executed
        {
            get { return _executed; }
        }

        public abstract bool Success {  get; }

        public bool Reversed
        {
            get { return _reversed; }
        }

        public DateTime DateStamp
        {
            get { return _dateStamp; }
        }

        public abstract void print();

        public virtual void Execute()
        {
            if (Executed)
            {
                throw new Exception("Transaction Already Executed");
            }
            _executed = true;
            _dateStamp = DateTime.Now;
        }

        public virtual void Rollback()
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
            _dateStamp = DateTime.Now;
        }
       
    }
}
