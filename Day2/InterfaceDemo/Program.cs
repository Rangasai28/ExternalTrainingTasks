using System.Text;
using System.Xml.Linq;

namespace InterfaceDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SavingsAccount sAccount = new SavingsAccount("Bala",30000,(decimal)0.02,25000);
            CurrentAccount cAccount = new CurrentAccount("Ranga", 30000, 25000, 5000);

            IAccount savingsAccount = sAccount;
            IAccount currentAccount = cAccount;

            //Executing Deposit and Withdraw Transaction Methods of Savings Account
            DepositTransaction(savingsAccount);
            Console.WriteLine();
            WithdrawTransaction(savingsAccount);
            Console.WriteLine();
            Details(savingsAccount);

            //Executing Deposit and Withdraw Transaction Methods of Current Account

            DepositTransaction(currentAccount);
            Console.WriteLine();
            WithdrawTransaction(currentAccount);
            Console.WriteLine();
            Details(currentAccount);
        }

        public static void DepositTransaction(IAccount Account)
        {
            Console.WriteLine("Enter Amount To Deposit:");
            decimal Amount = Convert.ToDecimal(Console.ReadLine());

            if (Account.Deposit(Amount))
            {
                Console.WriteLine($"The Amount {Amount} is Deposited into {Account.Name} Account And Available Balance is {Account.Balance}");
            }
        }

        public static void WithdrawTransaction(IAccount Account)
        {
            Console.WriteLine("Enter Amount To Withdraw:");
            decimal Amount = Convert.ToDecimal(Console.ReadLine());
            if (Amount < Account.WithdrawLimit)
            {
                if (Account.Withdraw(Amount))
                {
                    Console.WriteLine($"The Amount {Amount} is Withdraw from {Account.Name} Account And Available Balance is {Account.Balance}");
                }
                else
                {
                    Console.WriteLine("Please Enter Valid Amount");
                }
            }
            else
            {
                Console.WriteLine("Amount Entered is Exceding the Withdraw Limit ");
            }

           
        }

        public static void Details(IAccount Account)
        {
            Console.WriteLine(Account.getDetails());
        }
    }
}
