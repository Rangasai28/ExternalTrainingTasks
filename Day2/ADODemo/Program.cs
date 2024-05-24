namespace ADODemo
{
    internal class Program
    {
        public enum MenuOption
        {
            Add = 1,
            Delete,
            Update,
            Print,
            Quit
        }
        static void Main(string[] args)
        {
            
            MenuOption uoption = Program.ReadUserOption();
            do
            {

                switch (uoption)
                {
                    case MenuOption.Add:
                        InputOutput.AddEmp();
                        break;
                    case MenuOption.Delete:
                        InputOutput.DeleteEmp();
                        break;
                    case MenuOption.Update:
                        InputOutput.UpdateEmp();
                        break;

                    case MenuOption.Print:
                        InputOutput.getAllEmployees();
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
                uoption = Program.ReadUserOption();
            }
            while (Convert.ToInt32(uoption) != 5);
            Console.WriteLine();
        }
        public static MenuOption ReadUserOption()
        {

            MenuOption  option = MenuOption.Add;


            do
            {
                Console.WriteLine((int)option + " " + option);

                option++;
            }
            while (option <= MenuOption.Quit);
            Console.WriteLine();
            Console.Write("Select Option From the Above Menu :");
            int userOption = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            return (MenuOption)userOption;

        }
    }
}
