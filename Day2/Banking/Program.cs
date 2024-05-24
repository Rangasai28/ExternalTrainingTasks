namespace Banking
{
    
    public enum MenuOption
    {
        Withdraw = 1,
        Deposit,
        Transfer,
        Print,
        Quit
    }

    

    public class Program
    {
        
        static void Main(string[] args)
        {

            Account obj = new("Bala", 30000);
           

        MenuOption uoption = ReadUserOption();
            do
            {

                switch (uoption)
                {
                    case MenuOption.Withdraw:
                        DoWithdraw(obj);
                        break;
                    case MenuOption.Deposit:
                        DoDeposit(obj);
                        break;
                    case MenuOption.Transfer:
                        DoTransfer(obj);
                        break;
                    case MenuOption.Print:
                        DoPrint(obj);
                        break;
                    case MenuOption.Quit:
                        break;
                    default:
                        Console.WriteLine(" Please Enter valid Input");
                        break;
                }
                if (Convert.ToInt32(uoption) == 5)
                {

                    break;
                }
                uoption = ReadUserOption();
            }
            while (Convert.ToInt32(uoption) != 5);
            Console.WriteLine("Transaction Ended");

        }
        public static MenuOption ReadUserOption()
        {
            MenuOption option = MenuOption.Withdraw;


            // Iterate over the enum values using a do-while loop
            do
            {
                Console.WriteLine((int)option + " " + option);
                // Increment the enum variable to the next value
                option++;
            }
            while (option <= MenuOption.Quit);
            Console.WriteLine("Select One of the Option From the Above Menu:");
            int userOption = Convert.ToInt32(Console.ReadLine());

           // Console.WriteLine(userOption);
            return (MenuOption)userOption;


        }
        public static void DoDeposit(Account obj)
        {
            
            Console.WriteLine("Enter The Amount to Deposit:");
            decimal deAmount = Convert.ToDecimal(Console.ReadLine());
            DepositTransaction dT = new DepositTransaction(obj,deAmount);
            dT.Execute();
            Console.WriteLine(dT.print());
        }

        public static void DoWithdraw(Account obj)
        {
            
            Console.WriteLine("Enter The Amount to WithDraw:");
            decimal WiAmount = Convert.ToDecimal(Console.ReadLine());
            WithdrawTransaction wT = new WithdrawTransaction(obj,WiAmount);
            wT.Execute();
            
            Console.WriteLine( wT.print());
            
        }

        public static void DoTransfer(Account obj)
        {
            Console.WriteLine("Enter Second Account Holder Name:");
            string sname  = Console.ReadLine();

            Account obj2 = new Account(sname, 40000); 

            Console.WriteLine("Enter The Amount to Transfer:");
            decimal transferAmount = Convert.ToDecimal(Console.ReadLine());

            TransferTransaction tR = new TransferTransaction(obj,obj2,transferAmount);
            tR.Execute();
            Console.WriteLine(tR.print());
        }

        public static void DoPrint(Account obj)
        {
            Console.WriteLine(obj.getBalance());
           // Console.WriteLine(obj2.getBalance());
        }

       

       

    }
}
