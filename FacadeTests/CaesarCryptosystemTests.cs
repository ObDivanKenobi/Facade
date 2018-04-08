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
    public class CaesarCryptosystemTests
    {
        [TestMethod()]
        public void CaesarCryptosystemTest()
        {
            CaesarCryptosystem test = new CaesarCryptosystem(2);
            string text = "test message";

            var sipher = test.Encrypt(text);
            string decodedText = test.Decode(sipher);

            Assert.AreEqual(text, decodedText);
        }
    }
}