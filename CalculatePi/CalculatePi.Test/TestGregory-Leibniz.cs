using NUnit.Framework;
using CalculatePi.Pi;
using System;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(1000, 0.0005)]
        [TestCase(10000, 0.00006)]
        [TestCase(1000000, 0.000001)]
        public void Test(int iterations, double expectedDifference)
        {
            var pi = new Gregory_Leibniz();
            pi.Iterations = iterations;
            Assert.That(Math.Abs(3.14159265359 - pi.Calculate()), Is.LessThan(expectedDifference));
        }
    }
}