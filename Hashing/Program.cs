using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashing
{
    class Program
    {
        static void Main(string[] args)
        {
            PasswordManager pwManager = new PasswordManager();

            pwManager.Save("lars", "pols");

            while (true)
            {
                Console.Write("Enter username >");
                var username = Console.ReadLine();

                Console.Write("Enter password >");
                string password = "";

                #region Password masking

                // This piece of code masks the input when entering the password. 
                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    // Backspace Should Not Work
                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        password += key.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                        {
                            password = password.Substring(0, (password.Length - 1));
                            Console.Write("\b \b");
                        }
                        else if (key.Key == ConsoleKey.Enter)
                        {
                            Console.WriteLine();
                            break;
                        }
                    }
                } while (true); // End of password masking
                #endregion

                if (pwManager.Authenticate(username, password))
                {
                    // secure area
                    Console.WriteLine("Login successful...");
                    Console.WriteLine("I'm ready to share my secrets...");
                    Console.ReadLine();
                }
                else
                {
                    // unsecure area
                    Console.WriteLine("Invalid login...");
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                    Console.Clear();
                }

            }
        }
    }
}
