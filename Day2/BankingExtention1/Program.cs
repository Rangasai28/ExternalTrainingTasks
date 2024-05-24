namespace BankingExtention1
{
    //Menuoption Enumerator
    public enum MenuOption
    {
        NewAccount =1,
        Withdraw ,
        Deposit,
        Transfer,
        Print,
        Quit
    }


    public class Program
    {

        static void Main(string[] args)
        {

            Bank bank = new Bank();


            MenuOption uoption = ReadUserOption();
            do
            {

                switch (uoption)
                {
                    case MenuOption.NewAccount:
                        CreateNewAccount(bank);
                        break;
                    case MenuOption.Withdraw:
                        DoWithdraw(bank);
                        break;
                    case MenuOption.Deposit:
                        DoDeposit(bank);
                        break;
                    case MenuOption.Transfer:
                        DoTransfer(bank);
                        break;
                    case MenuOption.Print:
                        DoPrint(bank);
                        break;
                    case MenuOption.Quit:
                        break;
                    default:
                        Console.WriteLine(" Please Enter valid Input");
                        break;
                }
                if (Convert.ToInt32(uoption) == 6)
                {

                    break;
                }
                uoption = ReadUserOption();
            }
            while (Convert.ToInt32(uoption) != 6);
            Console.WriteLine("Transaction Ended");

        }

        //Method That Returns User Option
        public static MenuOption ReadUserOption()
        {
            MenuOption option = MenuOption.NewAccount;


            // Iterate over the enum values using a do-while loop
            do
            {
                Console.WriteLine((int)option + " " + option);
                // Increment the enum variable to the next value
                option++;
            }
            while (option <= MenuOption.Quit);
            Console.Write("Select One of the Option From the Above Menu:");
            int userOption = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            // Console.WriteLine(userOption);
            return (MenuOption)userOption;


        }

        //Method Thar Creats new Bank Account
        public static void CreateNewAccount(Bank tobank)
        {
          

            Console.Write("Enter Name Of the  Account Holder:");
            string Name = Console.ReadLine();

            Console.Write("Enter Staring Balance:");
            decimal sbalance = Convert.ToDecimal(Console.ReadLine());

           

            tobank.AddAccount(new Account(Name, sbalance));
            Console.WriteLine("Account Created Successfully");
            Console.WriteLine();
            


        }

        //Method Thar Performs Deposit Transaction
        public static void DoDeposit(Bank tobank)
        {

            Account todeposit = FindAccount(tobank);
            if (todeposit == null) return;

            Console.Write("Enter The Amount To Deposit:");
            decimal deAmount = Convert.ToDecimal(Console.ReadLine());
            if (deAmount <= 0)
            {
                Console.WriteLine("Amount can not be Negative");
                DoDeposit(tobank);
            }

            DepositTransaction dT = new DepositTransaction(todeposit, deAmount);
            tobank.ExecuteTransaction(dT);

            dT.print();
        }

        //Method That Performs Withdraw Transaction
        public static void DoWithdraw(Bank tobank)
        {

            Account towithdraw = FindAccount(tobank);

            if (towithdraw == null) return;
            Console.Write("Enter The Amount To WithDraw:");
            decimal wiAmount = Convert.ToDecimal(Console.ReadLine());
            if (wiAmount <= 0)
            {
                Console.WriteLine("Please Check the Amount ");
                DoWithdraw(tobank);
            }

            WithdrawTransaction wT = new WithdrawTransaction(towithdraw, wiAmount);
            tobank.ExecuteTransaction(wT);

            wT.print();

        }

        //Method That Perform Transfer Transaction
        public static void DoTransfer(Bank tobank)
        {

            Account fromAccount = FindAccount(tobank);
            Account toAccount = FindAccount(tobank);

            if(fromAccount == null || toAccount == null) return;

            Console.WriteLine("Enter The Amount to Transfer:");
            decimal transferAmount = Convert.ToDecimal(Console.ReadLine());

            if(transferAmount <= 0)
            {
                Console.WriteLine("Please Check the Amount ");
                DoTransfer(tobank);
            }

            TransferTransaction tR = new TransferTransaction(fromAccount, toAccount, transferAmount);
            tobank.ExecuteTransaction(tR);
            tR.print();
        }

        //Method That Displays Account in the List<Account>
        public static void DoPrint(Bank tobank)
        {
            Account acc = FindAccount(tobank);
            Console.WriteLine("Account Name = {0}", acc.name);
            Console.WriteLine("Account Balance = {0}", acc.balance);    
            Console.WriteLine();

        }


        //Method To Find an Account Based On the Account Holders Name
        private static Account FindAccount(Bank bank)
        {
            Console.Write("Enter Account Holders Name :");
            string name = Console.ReadLine();

            Account result = bank.GetAccount(name);
            if(result == null)
            {
                Console.WriteLine($"No Account is Found With the Specified Name : {name}");
                Console.WriteLine("Transaction Ended");
                Console.WriteLine();
            }
            return result;
        }


    }
}
