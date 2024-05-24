namespace ArraysDemo
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Program.singleDArray();
            Program.TwoDArray();
            Program.JaggedArrays();
            Program.StringArrays();
        }

        public static void singleDArray()
        {
            int[] number;
            number = ArrayTypes.assignArrayValues(10);
            ArrayTypes.PrintArray(number);
            ArrayTypes.arrayMethodsDemo(new int[10]);
            
        }
   
        public static void TwoDArray()
        {
            //Assigning values to 2_D Array at the time of it’s declaration
            int[,] firstArray = { {1,2,3 },{4,5,6} };
            int[,] secondArray = new int[2, 3] { { 4,5,6}, {7,8,9} };


            //Accessing 2_D array using foreach loop
            Console.WriteLine("Displaying Two Dimentional Array");
            TwoDimentionalArray.PrintArray(secondArray);
            TwoDimentionalArray.PrintArray(firstArray);


           
            Console.WriteLine();
        }

        public static void JaggedArrays()
        {   

            //Declaration of Jagged Array
            int[][] arr;
            arr = new int[4][];
            arr[0] = new int[] { 1, 2, 3, 4, 5 };
            arr[1] = new int[] { 2, 3, 4, 5, 6, 7, 8, 9 };
            arr[2] = new int[] {2,1, 3, 4, 5,6, 7, 8,9};
            arr[3] = new int[] { 3, 4, 5, 2, 6, 7, };

            Console.WriteLine("Displaying Jagged Array");
            JaggedArray.PrintArray(arr);
        }

        public static void StringArrays()
        {
            string[] fruits = { "Apple", "Banana", "Orange", "Grape", "Mango" };
            Console.WriteLine("Displaying String Array Elements");
            StringArray.PrintArray(fruits);

            string[] vehicals = StringArray.assignStringValues(4);
            StringArray.PrintArray(vehicals);
        }


    }
}
