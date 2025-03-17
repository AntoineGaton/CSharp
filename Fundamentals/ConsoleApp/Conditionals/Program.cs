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

            if (age >= 18)
            {
                Console.WriteLine($"Hey {name}, it seems like you are an adult.");
            }
            else if (age >= 13)
            {
                Console.WriteLine($"Hey {name}, it seems like you are a teenager.");
            }
            else
            {
                Console.WriteLine($"Hey {name}, it seems you are a minor.");
            }
        }
    }
}
