using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysDemo
{
    public class ArrayTypes
    {
        public static void arrayMethodsDemo(int[] arr1)
        {
            int[] arr = { 54, 79, 59, 8, 42, 22, 93, 3, 73, 38, 67, 48, 18, 61, 32, 86, 15, 27, 81, 96 };
            ArrayTypes.PrintArray(arr);
            Console.WriteLine();

            //Sorting An array
            Array.Sort(arr);
            Console.WriteLine("Array Elements After Sorting");
            ArrayTypes.PrintArray(arr);
            Console.WriteLine();

            //Reversing an Array
            Array.Reverse(arr);
            Console.WriteLine("Array Elements After Reversing");
            ArrayTypes.PrintArray(arr);
            Console.WriteLine();

            //Copying elements from one array to other array
            Array.Copy(arr, arr1, 9);

            //Printing Destination Array
            Console.WriteLine("Printing Destination Array");
            ArrayTypes.PrintArray(arr1);

            //GetLength() Method
            Console.WriteLine();
            Console.WriteLine("Length of Arr is {0} and Length of Arr1 is {1}", arr.GetLength(0), arr1.GetLength(0));
            Console.WriteLine();


           

        }

        //Method That Assign Values to an array 
        public static int[] assignArrayValues(int length)
        {
            int[] arr = new int[length];
            Console.WriteLine("Enter Array Elements:");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            return arr;
        }

        //Method that Print One Dimentional Array Elements
        public static void PrintArray(int[] value)
        {
            foreach (int i in value)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }

    public class TwoDimentionalArray
    {
        public static void PrintArray(int[,] arr)
        {
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }

    public class JaggedArray
    {
        public static void PrintArray(int[][] arr)
        {
            foreach (int[] i in arr)
            {
                foreach (int i1 in i)
                {
                    Console.Write(i1 + " ");
                }
                Console.WriteLine();
            }
        }
    }

    public class StringArray
    {
        public static void PrintArray(string[] arr)
        {
            foreach (string i in arr)
            {
               
                 Console.Write(i + " ");
                
            }
            Console.WriteLine();
        }

        public static string[] assignStringValues(int length)
        {
            string[] arr = new string[length];
            Console.WriteLine("Enter String Array Elements:");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Console.ReadLine();
            }
            return arr;
        }
    }



}
