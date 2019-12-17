using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.W._2019.Titkov._13;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Titkov._13.Tests
{
    [TestClass()]
    public class QueueTests
    {
        [TestMethod()]
        public void EnqueueTest()
        {
            // Arrange
            Queue<string> queue = new Queue<string>();
            var expected = "Test string";

            // Act
            queue.Enqueue("Test string");
            var actual = queue.Peek();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DequeueTest()
        {
            // Arrange
            Queue<string> queue = new Queue<string>();
            var expected = "Test string";

            // Act
            queue.Enqueue("Test string");
            var actual = queue.Dequeue();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PeekTest()
        {
            // Arrange
            Queue<string> queue = new Queue<string>();
            var expected = "Test string";

            // Act
            queue.Enqueue("Test string");
            var actual = queue.Peek();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ContainsTest()
        {
            // Arrange
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("Test string");
            var expected = "Test string";

            // Act
            var isContains = queue.Contains(expected);

            // Assert
            Assert.IsTrue(isContains);
        }

        [TestMethod()]
        public void ClearTest()
        {
            // Arrange
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("Test string");
            var expected = 0;

            // Act
            queue.Clear();
            var actual = queue.Count;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}