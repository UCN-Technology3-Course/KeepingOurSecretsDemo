using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecryptAndEncrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Write your secret: ");
            var input = Console.ReadLine();

            Console.Write("Enter password: ");
            var encryptedSecret = Encrypt.EncryptString(input, Console.ReadLine());
            Console.WriteLine(encryptedSecret);

            Console.ReadLine();

            Console.Write("Enter password: ");
            var decryptedSecret = Encrypt.DecryptString(encryptedSecret, Console.ReadLine());
            Console.WriteLine(decryptedSecret);
        }
    }
}
