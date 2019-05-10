﻿using NUnit.Framework;
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
        [TestCase(1000, 0.0005)]
        [TestCase(10000, 0.00006)]
        [TestCase(1000000, 0.000001)]
        public void Test_NumberOfIterations(int iterations, double expectedDifference)
        {
            var pi = new Nilikantha();
            pi.NumberOfIterations = iterations;
            Assert.That(Math.Abs(0.14159265359 - pi.Calculate()), Is.LessThan(expectedDifference));
        }

        [Test]
        [TestCase(0, 1000, 3.1410926)]
        [TestCase(0, 1000000, 3.14159265359)]
        [TestCase(500, 1000, 0.0004999)]
        public void Test_Iterations(int startIteration, int numberOfIterations, double expected)
        {
            var pi = new Nilikantha();
            pi.Iterations(startIteration, numberOfIterations);
            Assert.That(Math.Abs(expected - pi.Calculate()), Is.LessThan(0.000001));
        }
    }
}