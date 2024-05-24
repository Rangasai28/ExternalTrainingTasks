using System;

namespace ExceptionsPractice
{
    internal class Program
    {
        static void safedividsion(int x, int y)
        {
            if (y == 0)
            {
                throw new DivideByZeroException("Cannot divide by Zero");
            }
        }

        static int getValue(int index)
        {
            int[] arra = { 1, 2, 3, 4, 5 };
            try
            {
                return arra[index];
            }
            catch (IndexOutOfRangeException e) when (index < 0)
            {
                throw new ArgumentOutOfRangeException(
                    "Parameter index cannot be negative.", e);
            }
            catch (IndexOutOfRangeException e)
            {
                throw new ArgumentOutOfRangeException(
                    "Parameter index cannot be greater than the array size.", e);
            }
        }
        static void Main(string[] args)
        {
            try
            {
                int x = 2;
                Console.WriteLine("Enter value of y:");
                int y = Convert.ToInt32(Console.ReadLine());
                safedividsion(2, y);
                Console.WriteLine(getValue(13));

            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid format");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("index cannot be < 0 and > array length");
            }

            Console.WriteLine("Printed After Handling the Exception");
        }
    }
}
