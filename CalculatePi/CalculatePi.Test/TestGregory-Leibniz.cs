using NUnit.Framework;
using CalculatePi.Pi;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var pi = new Gregory_Leibniz();
            pi.Calculate();
            Assert.AreEqual(3.1, pi.Calculate());
            Assert.Pass();
        }
    }
}