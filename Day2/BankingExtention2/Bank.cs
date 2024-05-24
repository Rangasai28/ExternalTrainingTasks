using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingExtention2
{
    public class Bank
    {

        //List For Storing Account Type
        List<Account> _account = new List<Account>();

        private List<Transaction> _transactions = new List<Transaction>();

        //Method that Adds Account into the Accounts List
        public void AddAccount(Account account) => _account.Add(account);



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
        public void ExecuteTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
            transaction.Execute();
        }


        public void PrintTransactionHistory()
        {
            foreach (Transaction transaction in _transactions)
            {
                Console.WriteLine(transaction.DateStamp);
                transaction.print();
            }
        }
       


        //Method that Returns Account List
        public List<Account> GetAccounts()
        {
            return _account;
        }
    }
}
