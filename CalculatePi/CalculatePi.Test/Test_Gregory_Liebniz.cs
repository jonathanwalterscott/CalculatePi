using NUnit.Framework;
using CalculatePi.Library;
using System;

namespace Tests
{
    public class Test_Gregory_Liebniz
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(1000, 0.0005)]
        [TestCase(10000, 0.00006)]
        [TestCase(1000000, 0.000001)]
        public void Test_NumberOfIterations(int iterations, double expectedDifference)
        {
            var pi = new Gregory_Leibniz();
            pi.NumberOfIterations = iterations;
            Assert.That(Math.Abs(3.14159265359 - pi.Calculate()), Is.LessThan(expectedDifference));
        }

        [Test]
        [TestCase(0, 1000, 3.1410926)]
        [TestCase(0, 1000000, 3.14159265359)]
        [TestCase(500, 1000, 0.0004999)]
        public void Test_Iterations(int startIteration, int numberOfIterations, double expected)
        {
            var pi = new Gregory_Leibniz();
            pi.Iterations(startIteration, numberOfIterations);
            Assert.That(Math.Abs(expected - pi.Calculate()), Is.LessThan(0.000001));
        }
    }
}