using System;
using CustomMath;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    /*
                А                          B
    I. 1) Выбор простых чисел (достаточно больших)
              p1, p2                     q1, q2
       2) Вычислить
             r_a = p1*p2    модуль     r_b = q1*q2
       phi(r_a) = (p1-1)(p2-1)    phi(r_b) = (q1-1)(q2-1)
     
    II. 4) Выбирается
               a     открытая экспонента   b
          1 < a < phi(r_a)           1 < b < phi(r_b)
        gcd(a, phi(r_a)) = 1       gcd(b, phi(r_b)) = 1

        5) Открытый ключ
            (r_a, a)                    (r_b, b)

        6) Вычислить секретный ключ
      alpha = a^-1 mod phi(r_a)  beta = b^-1 mod phi(r_b)

    III. Шифрование:
        m - сообщение
        m1 = m^b mod r_b - шифротекст
    IV. Расшифровка:
        m2 = m1^beta mod r_b
    */
    /// <summary>
    /// Методы для работы с RSA.
    /// </summary>
    public class RSA
    {
        private (int r, int q) _openKey;
        private int _privateKey;

        public RSA(int privateKey, (int r, int q) openKey)
        {
            _openKey = openKey;
            _privateKey = privateKey;
        }
        
        public ICollection<int> Encrypt(string message)
        {
            List<int> cryptoMessage = new List<int>();

            for (int i = 0; i < message.Length; ++i)
                cryptoMessage.Add(Encrypt((int)message[i], _openKey));

            return cryptoMessage;
        }

        public string Decode(ICollection<int> cryptoMessage)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < cryptoMessage.Count; ++i)
                builder.Append((char)Decrypt(cryptoMessage.ElementAt(i), _privateKey, _openKey.r));

            return builder.ToString();
        }

        /// <summary>
        /// Шифрование сообщения.
        /// </summary>
        /// <param name="m">сообщение</param>
        /// <param name="openKey">открытый ключ принимающей стороны,
        /// r - модуль (p1*p2 или q1*q2), e - открытая экспонента,
        /// взаимно простое с phi(r) число</param>
        /// <returns>шифротекст</returns>
        private static int Encrypt(int m, (int r, int e) openKey)
        {
            return Calculations.ModPow(m, openKey.e, openKey.r);
        }

        /// <summary>
        /// Расшифровка сообщения.
        /// </summary>
        /// <param name="m1">шифротекст</param>
        /// <param name="d">закрытый ключ</param>
        /// <param name="r">модуль (p1*p2 или q1*q2)</param>
        /// <returns>расшифрованное сообщение</returns>
        private static int Decrypt(int m1, int d, int r)
        {
            return Calculations.ModPow(m1, d, r);
        }
        
        /// <summary>        
        //Just to test github webhook
        /// </summary>
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
