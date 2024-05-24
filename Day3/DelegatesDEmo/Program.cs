using System.Reflection;
using System.Threading.Channels;

namespace DelegatesDEmo
{

    public delegate void MathDelegate(int x, int y);
    public delegate string WishDelegate(string str);
    public delegate void CalculatorDelegate(int a, int b, int c);
    public delegate void cal(int a, int b, int c,int d);
    public delegate void lambda();

    internal class Program
    {

        public static void AddNums(int x, int y, int z)
        {
            Console.WriteLine($"Sum of given 3 no's is: {x + y + z}");
        }
        public static string SayHello(string Name)
        {
            return $"Hello {Name}, have a nice day!";
        }
        static void Main(string[] args)
        {
           delegateDemo obj = new delegateDemo();

            MathDelegate math;
            cal cal1; 
            math = obj.Add;
            math += obj.Sub;
            math+= obj.Mul;
            math += obj.Div;
            math(40, 20);
            math(50, 25);


            WishDelegate wish;
            wish = SayHello;
            Console.WriteLine(wish("Bala"));
            Console.WriteLine(wish("Ranga"));

            CalculatorDelegate sumOfThree;
            sumOfThree = AddNums;
            sumOfThree(10, 20, 20);            
            sumOfThree(100, 20, 20);

            //Anonymous Methods

            cal1 = delegate (int x, int y, int z, int r)
            {
                Console.WriteLine(x+y+z+r);
            };

            cal1 = delegate (int x, int y, int z, int r)      { Console.WriteLine(x + y + z + r); };
            

            cal1 += delegate (int x, int y, int z, int r)
            {
                Console.WriteLine(x * x);
            };

           

          

            //Lambda Expressions
            cal1 += (a, b, c, d) => { 
                
                Console.WriteLine(a * b * c * d);
                Console.WriteLine(a-b-c-d);
            };

            cal1(100, 20, 5, 4);

            lambda value = () => { Console.WriteLine(10 + 20); };
            value();


            //Anonymous Types
            var Emp = new
            {
                Id = 1001,
                Name = "Raju",
                Job = "Manager",
                Salary = 50000.00,
                Status = true,
                Dept = new { Id = 10, Name = "Sales", Location = "Hyderabad" }
            };
            Console.WriteLine(Emp.GetType() + "\n");
            Print(Emp);
            Console.ReadLine();

        }
        public static void Print(dynamic d)
        {
            Console.WriteLine($"Employee Id: {d.Id}");
            Console.WriteLine($"Employee Name: {d.Name}");
            Console.WriteLine($"Employee Job: {d.Job}");
            Console.WriteLine($"Employee Salary: {d.Salary}");
            Console.WriteLine($"Employee Status: {d.Status}");
            Console.WriteLine($"Department Id: {d.Dept.Id}");
            Console.WriteLine($"Department Name: {d.Dept.Name}");
            Console.WriteLine($"Department Location: {d.Dept.Location}");
        }
    }
}
