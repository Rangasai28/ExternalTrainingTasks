namespace constructorDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Customer c1 = new Customer("Bala", 245677,"Delhi");
            Console.WriteLine(c1.getCustomerDetails());

            Customer c2 = new Customer("Ranga", 2354356,"Andhra");
            Console.WriteLine(c2.getCustomerDetails());
        }
    }
}
