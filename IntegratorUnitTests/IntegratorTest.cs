using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Integrator;

namespace IntegratorUnitTests
{
    // Mock expression that will always evaluate to 1
    class ExpressionMock : IExpression
    {
        public double by(double param)
        {
            return 1.0;
        }
    }

    [TestClass]
    public class IntegratorTests
    {
        [TestMethod]
        public void TestWithInterval()
        {
            ExpressionIntegrator integrator = new ExpressionIntegrator(new ExpressionMock());
            var result = integrator.Integrate(0, 1, 0.0001);

            Assert.AreEqual(1.0, result, 0.001);
        }

        [TestMethod]
        public void TestWithNegativeBegining()
        {
            ExpressionIntegrator integrator = new ExpressionIntegrator(new ExpressionMock());
            var result = integrator.Integrate(-0.5, 0.5, 0.0001);

            Assert.AreEqual(1.0, result, 0.001);
        }

        [TestMethod]
        public void TestWithNegativeInterval()
        {
            ExpressionIntegrator integrator = new ExpressionIntegrator(new ExpressionMock());
            var result = integrator.Integrate(-1, 0, 0.0001);

            Assert.AreEqual(1.0, result, 0.001);
        }

        [TestMethod]
        public void TestWithInvertedInterval()
        {
            ExpressionIntegrator integrator = new ExpressionIntegrator(new ExpressionMock());
            Assert.ThrowsException<FormatException>(() => integrator.Integrate(1, 0, 0.0001));
        }
    }
}
