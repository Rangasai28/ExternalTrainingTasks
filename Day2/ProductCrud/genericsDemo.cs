using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCrud
{
    public  class genericsDemo
    {
        public static T Add<T>(T a, T b)
        {
            dynamic d1 = a;
            dynamic d2 = b;
            dynamic c = d1 + d2; 
            return c;
        }
        public static string Details<T>(T obj)
        {
            dynamic d = obj;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Name = {0}{1}",d.productId,Environment.NewLine);
            return sb.ToString();
        }
        public static void Main(string[] args)
        {

            Product pro = new Product(102, "dam", "dsf", "sfdv", 456m);
            Product p = new Product(102,"dam","dsf","sfdv",456m);
            Console.WriteLine(genericsDemo.Add<int>(10, 20));
            Console.WriteLine(genericsDemo.Add<string>("Bala", "Ranga"));
            Console.WriteLine(genericsDemo.Details<Product>(p));
        }
    }
}
