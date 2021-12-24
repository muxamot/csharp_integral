using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Integrator;

namespace IntegratorUnitTests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void TestOperationsParsing()
        {
            string arrange = "2 - (2 + 2 * 2) / 2";
            var parser = new Parser(arrange);

            Assert.AreEqual("2 2 2 2 * + 2 / - ", parser.get());
        }

        [TestMethod]
        public void TestFunctionsParsing()
        {
            string arrange = "sin(0) * cos(1) + ln(1) + lg(1) - exp(x) + tg(0) / ctg(0)";
            var parser = new Parser(arrange);

            Assert.AreEqual("0 s 1 c * 1 n 1 g x e 0 t 0 z / + - + + ", parser.get());
        }

        [TestMethod]
        public void TestPriorityParsing()
        {
            string arrange = "sin((1 + 1) * 2) / (cos(2^2) + 3)";
            var parser = new Parser(arrange);

            Assert.AreEqual("1 1 + 2 * s 2 2 ^ c 3 + / ", parser.get());
        }

        [TestMethod]
        public void TestUnpairedBraces()
        {
            string arrange = "2 - (2 + 2 * 2 / 2";
            Assert.ThrowsException<FormatException>(() => new Parser(arrange));
        }
    }
}
