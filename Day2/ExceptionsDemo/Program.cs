using ExceptionDemo;

namespace ExceptionDemo
{

    public enum MenuOption
    {
        Withdraw = 1,
        Deposit,
        Print,
        Quit
    }



    public class Program
    {
        static void Main(string[] args)
        {
            Account obj = new("bala", 0);
            MenuOption uoption = Program.ReadUserOption();
            do
            {

                switch (uoption)
                {
                    case MenuOption.Withdraw:
                        Program.DoWithdraw(obj);
                        break;
                    case MenuOption.Deposit:
                        Program.DoDeposit(obj);
                        break;
                    case MenuOption.Print:
                        Program.DoPrint(obj);
                        break;
                    case MenuOption.Quit:
                        break;
                    //default:
                    //    Console.WriteLine(" Please Enter valid Input");
                    //    break;
                }
                if (Convert.ToInt32(uoption) == 4)
                {

                    break;
                }
                uoption = Program.ReadUserOption();
            }
            while (Convert.ToInt32(uoption) != 4);
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

        //Using Try catch Blocks
        public static void DoDeposit(Account variable)
        {
            try
            {
                Console.WriteLine("Enter The Amount to Deposit:");
                decimal deAmount = Convert.ToDecimal(Console.ReadLine());
                bool status = variable.Deposit(deAmount);
                if (status)
                {
                    Console.WriteLine("Transaction Success");
                    DoPrint(variable);
                }
                else
                {
                    Console.WriteLine("Deposition Failed ");
                    Console.WriteLine("Please Check The Amount You have Entered");
                    Console.WriteLine();
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

           

        }


        //Using Try Catch Blocks
        public static void DoWithdraw(Account variable)
        {
            try
            {

                Console.WriteLine("Enter The Amount to WithDraw:");
                decimal WiAmount = Convert.ToDecimal(Console.ReadLine());
                bool status = variable.Withdraw(WiAmount);
                if (status)
                {
                    Console.WriteLine("Transaction Success");
                    DoPrint(variable);

                }
                else
                {
                    Console.WriteLine("WithDraw Failed");
                    Console.WriteLine("Please Check Your account Balance and Amount You have Entered");
                    Console.WriteLine();
                }
            }
            catch(FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            
           
           
        }

        public static void DoPrint(Account variable)
        {
            Console.WriteLine(variable.printBalance());
        }

       
      

    }
}
