using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsDemo
{
    public  class NonGenaricCollections
    {

        public static void displayElements<T>(T obj)
        {
           dynamic d = obj;
            foreach (var element in d )
            {
                Console.WriteLine(element.ToString());
            }
        }
       

        public static void displaykeyvalueElements<T>(T list)
        {
            dynamic d = list;
            foreach (DictionaryEntry entry in d)
            {
                Console.WriteLine($"Name: {entry.Key}, Salary: {entry.Value}");
            }
            Console.WriteLine() ;
        }

       


    }
}
