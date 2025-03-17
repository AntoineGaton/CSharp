using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Datatypes
{
    class Program
    {
        static void Main(string[] args)
        {

            // Displayed a message to the console. Uses System library, Console class, WriteLine method.
            Console.WriteLine("Revewing and freshening up my C# knowledge and skills!\n");

            // Declared similar data types in one line. This is called a multi-variable declaration.
            int x = 10, y = 20, z = 30;
            Console.WriteLine("The value of x,y,z is " + x + "," + y + "," + z + "\n");

            /* NUMERIC DATATYPES */

            // Declared an int which is a 32-bit signed integer.
            int age = 36;
            Console.WriteLine($"I am {age} years old.");
            Console.WriteLine($"The minimum int value: {int.MinValue}");
            Console.WriteLine($"The maximum int value: {int.MaxValue}\n");

            // Declared a long which is a 64-bit signed integer. Used L suffix to indicate it is a long.
            long bigNumber = 900000000L;
            Console.WriteLine($"The value of long variable bigNumber is {bigNumber}");
            Console.WriteLine($"The minimum long value: {long.MinValue}");
            Console.WriteLine($"The maximum long value: {long.MaxValue}\n");

            // Declared a float which is a 32-bit single-precision floating point. Used F suffix to indicate it is a float.
            float precisionNumber = 123.456F;
            Console.WriteLine($"The value of float variable precisionNumber is {precisionNumber}");
            Console.WriteLine($"The minimum float value: {float.MinValue}");
            Console.WriteLine($"The maximum float value: {float.MaxValue} \n");

            // Declared a double which is a 64-bit double-precision floating point. Used D suffix to indicate it is a double.
            double negativeNumber = -123.456D;
            Console.WriteLine($"The value of double variable negativeNumber is {negativeNumber}");
            Console.WriteLine($"The minimum double value: {double.MinValue}");
            Console.WriteLine($"The maximum double value: {double.MaxValue} \n");

            // Declared a decimal which is a 128-bit high precision decimal floating point. Used M suffix to indicate it is a decimal.
            decimal money = 123.45M;
            Console.WriteLine($"The value of decimal variable money is ${money}");
            Console.WriteLine($"The minimum decimal value: {decimal.MinValue}");
            Console.WriteLine($"The maximum decimal value: {decimal.MaxValue}\n");

            /* STRING DATATYPE */
            string name = "Antoine Gaton";
            char letter = 'A';
            Console.WriteLine($"My name is {name} and it starts with the letter {letter}.\n");

            string faveNumber = "7";
            int favNum = Convert.ToInt32(faveNumber);
            Console.WriteLine($"My favorite number is {favNum}.\n");

            /* BOOLEAN DATATYPE */
            bool isTrue = true;
            bool isFalse = false;
            Console.WriteLine($"The value of isTrue is {isTrue} and isFalse is {isFalse}.\n");

            /* OPERATORS */
            int count = 0;
            Console.WriteLine($"The value of count is {count}.");
            count++;
            Console.WriteLine($"The value of count right now is {count}.");

            count += 5;
            Console.WriteLine($"The value of count after adding 5 is {count}.");
            count /= 2;
            Console.WriteLine($"The value of count after dividing by 2 is {count}.");
            count *= 4;
            Console.WriteLine($"The value of count after multiplying by 4 is {count}.\n");

            int even = 10 % 2;
            int odd = 11 % 2;
            Console.WriteLine($"The value of even is {even} and the value of odd is {odd}.\n");

            // Unicode character
            char unicodeChar = '\u2022';
            Console.WriteLine($"The unicode character is {unicodeChar}");
            unicodeChar++;
            Console.WriteLine($"The next unicode character is {unicodeChar}\n");

            /* VAR KEYWORD */
            var myName = "Antoine Gaton";
            var myAge = 36;
            var myFaveNumber = 7;
            Console.WriteLine($"My name is {myName}, I am {myAge} years old, and my favorite number is {myFaveNumber}.\n");
            // NOTE: The var keyword is used to declare a variable without explicitly specifying the data type. The compiler will infer the data type based on the value assigned to the variable.

            /* CONSTANTS */
            const double PI = 3.14159;
            Console.WriteLine($"The value of PI is {PI}.\n");
            // NOTE: Constants are variables whose values cannot be changed once assigned. The const keyword is used to declare a constant.

            /* USER INPUT */
            Console.Write("Please enter your name: ");
            string userName = Console.ReadLine();
            Console.WriteLine($"Hello, {userName}! Welcome to the C# programming world.\n");

            Console.ReadLine();
        }
    }
}
