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
    public class JaggedArrayTests
    {
        [TestMethod()]
        public void SortBySumOfElementsInARowTest()
        {
            // Arrange
            int[][] actual = new int[][]
            {
                new int[] { 1, 3, 5, 7, 9 },
                new int[] { 11, 25, 99 },
                new int[] { 0, 2, 4, 6 },
                new int[] { 11, 22 }
            };

            int[][] expected = new int[][]
            {
                new int[] { 0, 2, 4, 6 },
                new int[] { 1, 3, 5, 7, 9 },
                new int[] { 11, 22 },
                new int[] { 11, 25, 99 }
            };

            // Act
            JaggedArray.SortBySumOfElementsInARow(actual);

            // Assert
            for (int i = 0; i < actual.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod()]
        public void SortByMaxInRowTest()
        {
            // Arrange
            int[][] actual = new int[][]
            {
                new int[] { 1, 3, 5, 7, 9 },
                new int[] { 11, 25, 99 },
                new int[] { 11, 22 },
                new int[] { 0, 2, 4, 6 }
            };

            int[][] expected = new int[][]
            {
                new int[] { 0, 2, 4, 6 },
                new int[] { 1, 3, 5, 7, 9 },
                new int[] { 11, 22 },
                new int[] { 11, 25, 99 }
            };

            // Act
            JaggedArray.SortByMaxInRow(actual);

            // Assert
            for (int i = 0; i < actual.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod()]
        public void SortByMinInRowTest()
        {
            // Arrange
            int[][] actual = new int[][]
            {
                new int[] { 1, 3, 5, 7, 9 },
                new int[] { 11, 22 },
                new int[] { 0, 2, 4, 6 },
                new int[] { 2, 25, 99 }
            };

            int[][] expected = new int[][]
            {
                new int[] { 0, 2, 4, 6 },
                new int[] { 1, 3, 5, 7, 9 },
                new int[] { 2, 25, 99 },
                new int[] { 11, 22 }
            };

            // Act
            JaggedArray.SortByMinInRow(actual);

            // Assert
            for (int i = 0; i < actual.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}