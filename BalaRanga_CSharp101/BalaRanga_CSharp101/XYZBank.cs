using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BalaRanga_CSharp101
{
    internal class XYZBank
    {
        List<Account> accounts = new List<Account>();

        public void AddAccount(Account account) => accounts.Add(account);



        //Method that Returns an Account Based on Account Holders Name
        public Account GetAccount(string name)
        {


            foreach (var account in accounts)
            {
                if (account.Name == name)
                {
                    return account;
                }

            }
            return null;

        }

        



    }
}
