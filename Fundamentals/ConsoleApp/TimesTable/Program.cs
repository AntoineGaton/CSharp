using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesTable
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Ask the user for a number and display the times table for that number.
            */
            
            Console.Write("Enter a number to create times table: ");
            int number = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= 12; i++)
            {
                Console.WriteLine("{0} x {1} = {2}", number, i, number * i);
            }

            Console.ReadLine();

        }
    }
}
