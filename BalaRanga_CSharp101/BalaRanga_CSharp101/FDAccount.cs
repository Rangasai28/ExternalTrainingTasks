using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalaRanga_CSharp101
{
    internal class FDAccount : Account
    {

        int count;

        public FDAccount(String name,decimal balance)
        {
            _name = name;
            _balance = balance;
        }
        public override string Deposit(decimal amount)
        {
            if (count == 0)
            {
                if (amount > 0)
                {

                    _balance += amount;
                    count = 1;
                    return ("Successful Transaction");
                
                }
                return ("UnSuccessful Transaction");
            }
            else
            {
                return ("UnSuccessful Transaction Limit Excceded");
            }
        }

        

        public override string Withdraw(decimal amount)
        {
            
            if (amount > 0 && amount <= _balance && count == 0)
            {
                _balance -= amount;
                count = 1;
                return("Successful Transaction");
               
            }
            return ("UnSuccessful Transaction Limit Excceded "); 
        }

        public override string Print()
        {
            return ($"Available Balance in {Name}'s FDAccount is {Balance}");
        }
    }
}
