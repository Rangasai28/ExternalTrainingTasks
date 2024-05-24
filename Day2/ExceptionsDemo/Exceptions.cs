using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsDemo
{

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    internal class Exceptions
    {
        //Nested Try catch
        public static void nestedtrycatch()
        {
           
               
             try
             {

                    Console.WriteLine("Enter Value of a:");
                    int a = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Value of b:");
                    int b = Convert.ToInt32(Console.ReadLine());

                try
                {

                        
                        int c = a / b;
                        Console.WriteLine(c);
                }
                catch(DivideByZeroException ex)
                {
                        Console.WriteLine(ex.Message);
                }
             }
             catch(FormatException ex)
             {
                    Console.WriteLine(ex.Message);
             }
                
                
            
        }


        //Index of Range
        public static void indexoutofrange()
        {
            
           int[][] arr = new int[4][];
            arr[0] = new int[] { 1, 2, 3, 4, 5 };
            arr[1] = new int[] { 2, 3, 4, 5, 6, 7, 8, 9 };
            arr[2] = new int[] { 2, 1, 3, 4, 5, 6, 7, 8, 9 };
            arr[3] = new int[] { 3, 4, 5, 2, 6, 7, };
            try
            {


                Console.WriteLine("Enter Index of the value");
                int index = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(arr[index][3]);
                Console.WriteLine(arr[index][5]);
                Console.WriteLine(arr[index][4]);
                Console.WriteLine(arr[index][3]);


            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Nullvalue Reference 
        public static void nullvaluereference()
        {
           

            try
            {
                Person person = null;
                string name = person.Name; 
                Console.WriteLine("Name of the person: " + name);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                
            }
        }
        static void Main(string[] args)
        {
            
            Exceptions.indexoutofrange();
          Exceptions.nullvaluereference();
            Exceptions.nestedtrycatch();
            
        }
       
    }


}
