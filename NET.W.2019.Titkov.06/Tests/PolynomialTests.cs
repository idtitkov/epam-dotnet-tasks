using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.W._2019.Titkov._06;

namespace NET.W._2019.Titkov._06.Tests
{
    [TestClass()]
    public class PolynomialTests
    {
        [TestMethod()]
        public void OperatorPlus()
        {
            // Arrange
            Polynomial p1 = new Polynomial(2, 5, 3, 9, 11);
            Polynomial p2 = new Polynomial(-8, 4, -1, 6);

            Polynomial expected = new Polynomial(2, -3, 7, 8, 17);

            // Act
            Polynomial actual = p1 + p2;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OperatorMinus()
        {
            // Arrange
            Polynomial p1 = new Polynomial(2, 5, 3, 9, 11);
            Polynomial p2 = new Polynomial(-8, 4, -1, 6);

            Polynomial expected = new Polynomial(2, 13, -1, 10, 5);

            // Act
            Polynomial actual = p1 - p2;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OperatorMultiply()
        {
            // Arrange
            Polynomial p1 = new Polynomial(2, 5, 3, 9, 11);
            Polynomial p2 = new Polynomial(-8, 4, -1, 6);

            Polynomial expected = new Polynomial(-16, -32, -6, -53, -25, 53, 43, 66);

            // Act
            Polynomial actual = p1 * p2;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            // Arrange
            Polynomial p1 = new Polynomial(2, 5, 3, 9, 11);
            string expected = "2x^4 + 5x^3 + 3x^2 + 9x + 11";

            // Act
            string actual = p1.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}