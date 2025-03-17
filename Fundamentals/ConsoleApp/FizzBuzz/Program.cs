using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Create a program that prints the numbers from 1 to user inpunt.
             * If a number is divisible by 3, print "Fizz" instead of the number.
             * If a number is divisible by 5, print "Buzz" instead of the number.
             * If a number is divisible by both 3 and 5, print "FizzBuzz" instead of the number.
            */

            bool isDivisibleBy3 = false;
            bool isDivisibleBy5 = false;
            int fizzBuzzCount = 0;
            int fizzCount = 0;
            int buzzCount = 0;
            int skipCount = 0;

            Console.Write("Provide a number to use in FizzBuzz: ");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("");

            for (int i = 1; i <= number; i++)
            {
                isDivisibleBy3 = i % 3 == 0;
                isDivisibleBy5 = i % 5 == 0;

                if (isDivisibleBy3 && isDivisibleBy5)
                {
                    Console.WriteLine("FizzBuzz");
                    fizzBuzzCount++;
                }
                else if (isDivisibleBy3)
                {
                    Console.WriteLine("Fizz");
                    fizzCount++;
                }
                else if (isDivisibleBy5)
                {
                    Console.WriteLine("Buzz");
                    buzzCount++;
                }
                else
                {
                    Console.WriteLine(i);
                    skipCount++;
                }
            }

            Console.WriteLine($"\nFizzBuzz occured {fizzBuzzCount} times.");
            Console.WriteLine($"Fizz occured {fizzCount} times.");
            Console.WriteLine($"Buzz occured {buzzCount} times.");
            Console.WriteLine($"Skipped {skipCount} numbers.");

            Console.ReadLine();
        }
    }
}
