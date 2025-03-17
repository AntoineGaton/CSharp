using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Provide a number to use in loops: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");

            /* FOR LOOPS */

            Console.WriteLine("Counting Upwards");
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("");

            Console.WriteLine("Counting Downwards");
            for (int i = 10; i > number; i--)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("");

            Console.WriteLine("Even Numbers");
            for (int i = 0; i <= number; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }

            Console.WriteLine("");

            Console.WriteLine("Odd Numbers");
            for (int i = 0; i <= number; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(i);
                }
            }

            Console.WriteLine("");

            Console.WriteLine("Count By Twos");
            for (int i = 0; i <= number; i += 2)
            {
                Console.WriteLine(i);
            }

            /* WHILE LOOPS */
            while (number > 0)
            {
                Console.WriteLine(number);
                number--;
            }

            /* DO WHILE LOOPS */
            int guess = 0;
            int actualNumber = new Random().Next(1, 101);
            int numberOfGuesses = 0;

            do
            {
                Console.WriteLine("\nLet's play a little guessing game.");
                Console.Write("Guess a number between 1 and 100: ");
                guess = Convert.ToInt32(Console.ReadLine());

                if (guess < actualNumber)
                {
                    Console.WriteLine("Too low. Try again.");
                    numberOfGuesses++;
                }
                else if (guess > actualNumber)
                {
                    Console.WriteLine("Too high. Try again.");
                    numberOfGuesses++;
                }
                else
                {
                    Console.WriteLine($"You got it! It took you {numberOfGuesses} guesses.");
                }
            } while (guess != actualNumber);

            Console.ReadLine();

        }
    }
}
