using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditionals
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What is your name: ");
            string name = Console.ReadLine();

            Console.Write("What is your age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            /* IF STATEMENTS */
            if (age >= 18)
            {
                Console.WriteLine($"Hey {name}, it seems like you are an adult.\n");
            }
            else if (age >= 13)
            {
                Console.WriteLine($"Hey {name}, it seems like you are a teenager.\n");
            }
            else
            {
                Console.WriteLine($"Hey {name}, it seems you are a minor.\n");
            }

            /* SWITCH STATEMENTS */
            Console.Write("Enter a day of the week: ");
            int day = Convert.ToInt32(Console.ReadLine());

            switch (day)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                    Console.WriteLine("Saturday");
                    break;
                case 7:
                    Console.WriteLine("Sunday");
                    break;
                default:
                    Console.WriteLine("Invalid day");
                    break;
            }

            Console.ReadLine();

        }
    }
}
