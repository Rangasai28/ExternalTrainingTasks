using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOPInheritenceDemo
{
    public class modifiersDemo
    {
        private int Id;
        protected int add(int a,int b)
        {
            int c = a + b;
            return c;
        }

        internal int Mul(int a,int b)
        {
            int d = a * b;
            return d;
        }
    }
}
