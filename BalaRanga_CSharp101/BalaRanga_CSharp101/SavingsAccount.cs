using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalaRanga_CSharp101
{
    internal class SavingsAccount : Account
    {
        int WtransactionCount, DtransactionCount;
        public SavingsAccount(string name,decimal balance) 
        {
            _name = name;
            _balance = balance;
        }
        public override string Deposit(decimal amount)
        {
            decimal Damount =0;
         
            if(WtransactionCount < 5 && Damount<50000)
            {
                if (amount > 0)
                {
                    _balance += amount;
                    Damount += amount;
                    WtransactionCount++;
                    return ("Successful");

                }
                else
                {
                    return ("UNSuccessful");
                }
                
            }
            else
            {
                return ("UnSuccessful Transaction Limit Excceded");
            }
           
            
        }

        public override string Print()
        {
            return($"Available Balance in {Name}'s SavingsAccount is {Balance}");
        }

        public override string  Withdraw(decimal amount)
        {
            decimal Wamount = 0;
            if (DtransactionCount < 5 && Wamount<50000)
            {
                if (amount > 0 && amount <= _balance && _balance > 1000)
                {
                    _balance -= amount;
                    DtransactionCount++;
                    Wamount += amount;
                    return ("Successful Transaction");
                }
                return ("UNSuccessful Tansaction");
            }
            else
            {
                return ("UnSuccessful Transaction Limit Excceded");
            }
           
            
        }
    }
}
