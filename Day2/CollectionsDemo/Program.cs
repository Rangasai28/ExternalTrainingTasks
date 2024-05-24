using System.Collections;
using System.Collections.Generic;

namespace CollectionsDemo
{
    internal class Program
    {
        public static void stack(Stack items)
        {   
            //Element is inserted above the Existing Element
            items.Push(101);

            items.Push("Bala");

            items.Push("30000m");

            items.Push(25534);

            //Displaying the Stack Elements
            NonGenaricCollections.displayElements<Stack>(items);
            Console.WriteLine();

            //Removes Last inserted Element and returns it
            items.Pop();
            Console.WriteLine();
            Console.WriteLine("After Pop");
            NonGenaricCollections.displayElements<Stack>(items);
            Console.WriteLine();

            Console.WriteLine("Poped Element is :{0}",items.Pop());

            NonGenaricCollections.displayElements<Stack>(items);
            Console.WriteLine();
            //Peek Returns the Top Element in the Stack.
            Console.WriteLine("Top Element is:{0}",items.Peek());
          
            Console.WriteLine();
            //Contains Search for the specified Element and returns true if it is present 
            Console.WriteLine(items.Contains(101));
            Console.WriteLine();

            //Displays Count of the Stack
            Console.WriteLine("Count Of the Queue is:{0}", items.Count);
            NonGenaricCollections.displayElements<Stack>(items);
        }

        public static void queue(Queue queue)
        {
            //Adding Element into the Queue
            queue.Enqueue('A');
            queue.Enqueue(100);
            queue.Enqueue(false);
            queue.Enqueue(34.56);
            queue.Enqueue("Hello");

            //Displaying Queue Elements
            NonGenaricCollections.displayElements<Queue>(queue);
            Console.WriteLine();

            //First inserted Element is Removed
            Console.WriteLine("Dequeud Element is :{0}", queue.Dequeue());
            Console.WriteLine();
            NonGenaricCollections.displayElements<Queue>(queue);

            //Returns First Element
            Console.WriteLine("First Element is:{0}", queue.Peek());

            //Displays Count of the Queue
            Console.WriteLine("Count Of the Queue is:{0}",queue.Count);

            //Displaying Queue Elements
            //Displaying Queue Elements
            NonGenaricCollections.displayElements<Queue>(queue);
        }

        public static void sortedlist(SortedList list)
        {
            //Adding Elements to the SortedList
               list.Add( "Bala",43234239m);
               list.Add("Ranga",300000m);
               list.Add( "Sai",100000m);
               list.Add( "Bob",30000m);

               NonGenaricCollections.displaykeyvalueElements<SortedList>(list); //Values are displayed in sorted order

            // Accessing elements by key
               Console.WriteLine("Salary of John: " + list["Bala"]);

                // Modifying existing element
                list["Sai"] = 350000m;

            NonGenaricCollections.displaykeyvalueElements<SortedList>(list);


            // Checking if a key exists 
            Console.WriteLine("Is Bob in the SortedList: " + list.ContainsKey("Bob"));

                // Checking if a value exists
                Console.WriteLine("Is salary 300000 in the SortedList: " + list.ContainsValue(300000m));

                // Removing an element
                list.Remove("Bob");
               
                // Checking the count of elements
                Console.WriteLine("Count of elements in the SortedList: " + list.Count);
                Console.WriteLine();

            NonGenaricCollections.displaykeyvalueElements<SortedList>(list);
        }

        public static void hashtable(Hashtable ht)
        {
            ht.Add(101, "Bala");
            ht.Add(102, "Ranga");
            ht.Add(103, "Sai");
            ht.Add(104, "Ravula");

            NonGenaricCollections.displaykeyvalueElements<Hashtable>(ht); //values are displayed randomly

            //Removies the element {104,"Ravula"}
            ht.Remove(104);
            NonGenaricCollections.displaykeyvalueElements<Hashtable>(ht);

            // Checking if a key exists 
            Console.WriteLine("Is 103 in the HashTable: " + ht.ContainsKey(103));

            // Checking if a value exists
            Console.WriteLine("Is Bala in the HashTable: " + ht.ContainsKey("Bala"));

            // Checking the count of elements
            Console.WriteLine("Count of elements in the HashTable: " + ht.Count);
            Console.WriteLine();

            object[] hashtableArray = new object[ht.Count];
            ht.CopyTo(hashtableArray, 0);

            // Displaying the copied array elements
            foreach (var item in hashtableArray)
            {
                Console.WriteLine(item);
            }



            try
            {
                int[] hashtablearray = new int[ht.Count];
                ht.CopyTo(hashtablearray, 0);

                // Displaying the copied array elements
                foreach (var item in hashtablearray)
                {
                    Console.WriteLine(item);
                }
            }
            catch(InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }
            NonGenaricCollections.displaykeyvalueElements<Hashtable>(ht);
        }

        static void Main(string[] args)
        {
            Stack items = new Stack();   //Last in First Out
            stack(items);

            Queue q = new Queue();   //First in First Out
            queue(q);

            SortedList sortedList = new SortedList(); //Stores elements based on KeyValue pairs in sorted order
            sortedlist(sortedList);

            Hashtable ht = new Hashtable(); //Stores elements based on KeyValue pairs k
            hashtable(ht);
        }
    }

}
   

