using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace PasswordChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Ask user for a password and check if it meets the following criteria:
             * - At least 8 characters long
             * - Contains at least one uppercase letter
             * - Contains at least one lowercase letter
             * - Contains at least one number
             * - Contains at least one special character
             * - If the password does not meet all criteria, display an error message and have them try again.
             * - If the password meets all criteria have them re-enter it to confirm.
             * - If the passwords match, display a success message.
            */
            bool isLooping = true;
            string password = string.Empty;

            do
            {
                Console.Write("Enter a password: ");
                password = Console.ReadLine();

                if (password.Length >= 8 && password.Any(char.IsUpper) && password.Any(char.IsLower) && password.Any(char.IsDigit) && password.Any(char.IsPunctuation))
                {
                    Console.Write("Re-enter your password to confirm password: ");
                    string confirmPassword = Console.ReadLine();
                    if (password == confirmPassword)
                    {
                        Console.WriteLine("Password successfully set!");
                        isLooping = false;
                    }
                    else
                    {
                        Console.WriteLine("Passwords do not match. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Password does not meet all criteria. Please try again.");
                }
            } while (isLooping);

           string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
           Console.WriteLine($"Hashed Password: {hashedPassword}");

           Console.ReadLine();
        }
    }
}
