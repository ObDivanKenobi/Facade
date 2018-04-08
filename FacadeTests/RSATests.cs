using Microsoft.VisualStudio.TestTools.UnitTesting;
using Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.Tests
{
    [TestClass()]
    public class RSATests
    {
        [TestMethod()]
        public void RSATest()
        {
            RSA test = new RSA(6111579, (9173503, 3));
            string text = "test message";

            var sipher = test.Encrypt(text);
            string decodedText = test.Decode(sipher);

            Assert.AreEqual(text, decodedText);
        }
    }
}