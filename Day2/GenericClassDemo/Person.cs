using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClassDemo
{
    public abstract class Person
    {
       
        public int Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public int ContactNumber { get; set; }

        public abstract string getDetails();

        public static int getId()
        {
            Console.WriteLine("Enter Id");
            int id = Convert.ToInt32(Console.ReadLine());
            return id;
        }
    }


}
