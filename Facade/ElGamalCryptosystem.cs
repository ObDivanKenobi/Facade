using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using CustomMath;

namespace Facade
{
    class ElGamalCryptosystem
    {
        private readonly int _secretKey;
        private readonly int _y;
        private readonly int _g;
        private readonly int _p;
        private int _sessionKey;

        public (int y, int g, int p) OpenKey => (_y, _g, _p);

        public ElGamalCryptosystem(int secretKey, int y, int g, int p, int sessionKey)
        {
            _secretKey = secretKey;
            _y = y;
            _g = g;
            _p = p;
            _sessionKey = sessionKey;
        }

        public ICollection<(int a, int b)> Encrypt(string message, int sessionKey)
        {
            List<(int a, int b)> cryptoMessage = new List<(int a, int b)>();

            for (int i = 0; i < message.Length; ++i)
                cryptoMessage.Add(Encrypt(message[i], sessionKey, OpenKey));

            return cryptoMessage;
        }

        public string Decode(ICollection<(int a, int b)> sipher)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < sipher.Count; ++i)
                builder.Append((char)Decode(_secretKey, _p, sipher.ElementAt(i)));

            return builder.ToString();
        }

        static (int a, int b) Encrypt(int q, int k, (int y, int g, int p) openKey)
        {
            int a = Calculations.ModPow(openKey.g, k, openKey.p),
                b = (int)(q * BigInteger.Pow(openKey.y, k) % openKey.p);

            return (a, b);
        }

        static int Decode(int secretKey, int p, (int a, int b) sipher)
        {
            int ax = (int)Math.Pow(sipher.a, secretKey);
            return sipher.b * Calculations.InvertNotCoprimeIntegers(ax, p) % p;
        }
    }
}
