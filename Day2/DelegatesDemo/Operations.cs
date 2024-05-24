using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DelegatesDemo
{
    public delegate void ArithmeticHandler(int numberOne, int numberTwo);
    public class Operations
    {
        public void Addition(int numberOne, int numberTwo)
        {
            Console.WriteLine("The Sum of {0} and {1} is {2}", numberOne, numberTwo, numberOne + numberTwo);
            Console.WriteLine();
        }

        public void Subtraction(int numberOne, int numberTwo)
        {
            Console.WriteLine("The Difference of {0} and {1} is {2}", numberOne, numberTwo, numberOne - numberTwo);
            Console.WriteLine();
        }

        public void Multipication(int numberOne, int numberTwo)
        {
            Console.WriteLine("The Multipication of {0} and {1} is {2}", numberOne, numberTwo, numberOne * numberTwo);
            Console.WriteLine();
        }
    }
}
