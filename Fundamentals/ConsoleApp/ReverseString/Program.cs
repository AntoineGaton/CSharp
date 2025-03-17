using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Ask user for a message and reverse it.
            */

            Console.Write("Enter a message: ");
            string message = Console.ReadLine();

            for (int i = message.Length - 1; i >= 0; i--)
            {
                Console.Write(message[i]);
                Thread.Sleep(100);
            }

            Console.ReadLine();


        }
    }
}
