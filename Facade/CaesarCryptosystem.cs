using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class CaesarCryptosystem
    {
        private int _shift;

        public CaesarCryptosystem(int shift)
        {
            _shift = shift;
        }

        public ICollection<int> Encrypt(string message)
        {
            List<int> cryptoMessage = new List<int>();

            for (int i = 0; i < message.Length; ++i)
                cryptoMessage.Add(Encrypt(message[i], _shift));

            return cryptoMessage;
        }

        public string Decode(ICollection<int> cryptoMessage)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < cryptoMessage.Count; ++i)
                builder.Append((char)Decrypt(cryptoMessage.ElementAt(i), _shift));

            return builder.ToString();
        }
        
        private static int Encrypt(int m, int shift)
        {
            return m + shift;
        }

        private static int Decrypt(int m, int shift)
        {
            return m - shift;
        }
        
        //Just to test github webhook
        private static void DoNothing()
        {
            int[] array = new[] { 1, 2, 3, 4, 5, 6, 7 };
            foreach (int i in array)
            {
                int a = i;
                int b = i*i*i;
            }
        }
    }
}
