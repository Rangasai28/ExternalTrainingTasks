namespace DelegatesDemo
{
    internal class Program
    {
       
        public static void Operations()
        {
            Operations obj = new Operations();

            ArithmeticHandler ar1, ar2, ar3, ar4;

            ar1 = new ArithmeticHandler(obj.Addition);
            ar2 = new ArithmeticHandler(obj.Subtraction);
            ar3 = new ArithmeticHandler(obj.Multipication);

            ar4 = ar1 + ar2 + ar3;

            //Performs Addition
            ar1(10, 20);

            //Performs Subtraction
            ar2(30, 10);

            //Performs Multipication
            ar3(10, 10);

            //Performs Above Three Operation on Same Parameter Values

            ar4(50, 30);
        }

        public static void trancations()
        {
            Account firstaccount = new Account("Bala", 30000);
            Account secondaccount = new Account("Sai", 40000);

            Transaction withdrawtra, deposittra;

            withdrawtra = new Transaction(firstaccount.Withdraw);
            deposittra = new Transaction(secondaccount.Deposit);


            //Performing Withdraw Transaction On firstaccount using Transaction Delegate
            

            if (withdrawtra(20000))
            {
                Console.WriteLine("Withdraw Transaction Successful");
                Console.WriteLine("Available Balance = {0} ", firstaccount.balance);
            }
            else
            {
                Console.WriteLine("Transaction Failed");
            }


            //Performing Deposit Transaction On Secondaccount using Transaction Delegate

            if (deposittra(20000))
            {
                Console.WriteLine("Deposit Transaction Successful");
                Console.WriteLine("Available Balance = {0} ", secondaccount.balance);
            }
            else
            {
                Console.WriteLine("Transaction Failed");
            }

        }
        static void Main(string[] args)
        {
            Operations();
            trancations();
        }
    }
}
