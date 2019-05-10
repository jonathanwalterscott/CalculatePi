using NUnit.Framework;
using CalculatePi.Pi;
using System;

namespace Tests
{
    public class Test_Nilikantha
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(1000, 0.14159265355858999)]
        [TestCase(10000, 0.14159265358975975)]
        [TestCase(1000000, 0.14159265358975975)]
        public void Test_NumberOfIterations(int iterations, double expected)
        {
            var pi = new Nilikantha();
            pi.NumberOfIterations = iterations;
            Assert.That(Math.Abs(expected - pi.Calculate()), Is.LessThan(0.000000001));
        }

        [Test]
        [TestCase(1, 10, 0.0082324013252137729)]
        [TestCase(0, 1000, 0.14159265355858999)]
        [TestCase(0, 1000000, 0.14159265358975975)]
        [TestCase(5, 10, 0.00015901616204533196)]
        public void Test_Iterations(int startIteration, int numberOfIterations, double expected)
        {
            var pi = new Nilikantha();
            pi.Iterations(startIteration, numberOfIterations);
            Assert.That(Math.Abs(expected - pi.Calculate()), Is.LessThan(0.000000001));
        }
    }
}