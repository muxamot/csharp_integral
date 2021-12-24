using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Integrator;

namespace IntegratorUnitTests
{
    // Mock for parser class
    // so parser bugs will not affect expression test
    class ParserMock : IParser
    {
        private string mocked_str_;
        public ParserMock(string str) {
            mocked_str_ = str;
        }

        public string get() {
            return mocked_str_;
        }
    };

    [TestClass]
    public class ExpressionTests
    {
        [TestMethod]
        public void TestEvaluation()
        {
            string arrange = "2 2 2 2 * + 2 / - ";
            IExpression expression = new Expression(new ParserMock(arrange));

            Assert.AreEqual(-1, expression.by(0));
        }

        [TestMethod]
        public void TestFunctionsEvaluation()
        {
            string arrange = "1 1 + 2 * s 2 2 ^ c 3 + / ";
            IExpression expression = new Expression(new ParserMock(arrange));

            Assert.AreEqual(-0.3225437, expression.by(0), 0.00001);
        }

        [TestMethod]
        public void TestParameterSubstitution()
        {
            double parameter = 3;
            string arrange = "1 1 + 2 * s 2 2 ^ c x + / ";
            IExpression expression = new Expression(new ParserMock(arrange));

            Assert.AreEqual(-0.3225437, expression.by(parameter), 0.00001);
        }

        [TestMethod]
        public void TestStackUnderflowed()
        {
            string arrange = "1 1 + 2 * s 2 ^ c 3 + / ";
            IExpression expression = new Expression(new ParserMock(arrange));

            Assert.ThrowsException<InvalidOperationException>(() => expression.by(0));
        }
    }
}
