using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDEmo
{
    internal class delegateDemo
    {
        public void Add(int x, int y)
        {
            Console.WriteLine($"Add: {x + y}");
        }
        public void Sub(int x, int y)
        {
            Console.WriteLine($"Sub: {x - y}");
        }
        public void Mul(int x, int y)
        {
            Console.WriteLine($"Mul: {x * y}");
        }
        public void Div(int x, int y)
        {
            Console.WriteLine($"Div: {x / y}");
        }
    }
}
