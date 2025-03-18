using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            /* List<T> */
            List<string> fruits = new List<string> { "Apple", "Banana", "Cherry" };

            // Add an item
            fruits.Add("Orange");

            // Remove an item
            fruits.Remove("Banana");

            // Check if an item exists
            bool hasCherry = fruits.Contains("Cherry");

            // Get the count
            int count = fruits.Count;

            // Print results
            Console.WriteLine(string.Join(", ", fruits)); // Output: Apple, Cherry, Orange
            Console.WriteLine($"Has Cherry: {hasCherry}"); // Output: Has Cherry: True
            Console.WriteLine($"Count: {count}"); // Output: Count: 3
            Console.WriteLine("Fruits currently available:");
            foreach( string fruit in fruits )
            {
                Console.WriteLine(fruit);
            }

            /* ARRAY */
            int[] numbers = new int[] {7, 18, 21, 36, 42, 55, 69, 85, 99, 101 };
            Console.WriteLine("Displaying even numbers in array:");

            foreach( int number in numbers )
            {
                if( number % 2 == 0 )
                {
                    Console.WriteLine(number);
                }
            }
        }
    }
}
