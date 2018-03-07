using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите шифруемое сообщение: ");
            string message = Console.ReadLine();
            RSA encryptor = new RSA(6111579, (9173503, 3));

            Console.WriteLine();
            Console.WriteLine("Шифротекст: ");

            var encryption = encryptor.Encrypt(message);
            foreach (int e in encryption)
                Console.Write($"{e} ");
            Console.WriteLine();

            message = encryptor.Decode(encryption);

            Console.WriteLine();
            Console.WriteLine("Обратная расшифровка: ");
            Console.WriteLine(message);

            Console.ReadLine();
        }
    }
}
