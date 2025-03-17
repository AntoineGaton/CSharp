using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryParse
{
    class Program
    {
        static void Main(string[] args)
        {
            bool success = true;

            while (success)
            {
                Console.Write("Enter a number: ");
                string input = Console.ReadLine();
                int number;
                success = int.TryParse(input, out number);
                if (success)
                {
                    Console.WriteLine("The number is: " + number);
                    success = false;
                }
                else
                {
                    Console.WriteLine("The input is not a number.");
                }
            }

            Console.ReadLine();
            // NOTE: Use TryParse to avoid exceptions when converting strings to numbers.
        }
    }
}
