using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingExtention1
{
    public class Bank
    {

        //List For Storing Account Type
        List<Account> _account  = new List<Account>();

        //Method that Adds Account into the Accounts List
        public void AddAccount(Account account)   =>    _account.Add(account);
        


        //Method that Returns an Account Based on Account Holders Name
        public Account GetAccount(string name)
        {
            
            
                foreach (var account in _account)
                {
                    if (account.name == name)
                    {
                        return account;
                    }

                }
                return null;
               
        }


        //Method That Executes WithdraTransaction
        public void ExecuteTransaction(WithdrawTransaction transaction) =>    transaction.Execute();
        


        //Method That Executes Deposit Transaction
        public void ExecuteTransaction(DepositTransaction transaction) => transaction.Execute();
        

        //Method That Executes Transfer Transaction
        
        public void ExecuteTransaction(TransferTransaction transaction) => transaction.Execute();


        //Method that Returns Account List
        public List<Account> GetAccounts()
        {
            return _account;
        }
    }
}
