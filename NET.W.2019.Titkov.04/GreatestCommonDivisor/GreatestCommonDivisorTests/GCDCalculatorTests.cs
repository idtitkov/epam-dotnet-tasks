using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreatestCommonDivisor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreatestCommonDivisor.Tests
{
    [TestClass()]
    public class GCDCalculatorTests
    {
        [TestMethod()]
        public void Euclid_300181and223744and38_19returned()
        {
            int num1 = 300181;
            int num2 = 223744;
            int num3 = 38;
            int expected = 19;

            int actual = GCDCalculator.Euclid(num1, num2, num3);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Euclid_128and0_128returned()
        {
            int num1 = 128;
            int num2 = 0;
            int expected = 128;

            int actual = GCDCalculator.Euclid(num1, num2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Euclid_ThrowsArgumentNullException()
        {
            int actual = GCDCalculator.Euclid(null);

            //// Assert - Expects exception
        }

        [TestMethod()]
        public void Stein_300181and223744and38_19returned()
        {
            int num1 = 300181;
            int num2 = 223744;
            int num3 = 38;
            int expected = 19;

            int actual = GCDCalculator.Stein(num1, num2, num3);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Stein_128and0_128returned()
        {
            int num1 = 128;
            int num2 = 0;
            int expected = 128;

            int actual = GCDCalculator.Stein(num1, num2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Stein_ThrowsArgumentNullException()
        {
            int actual = GCDCalculator.Stein(null);

            //// Assert - Expects exception
        }
    }
}