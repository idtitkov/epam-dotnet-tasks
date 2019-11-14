/*
Day 1 Task
Test of sorting.

Ivan Titkov 14.11.2019
*/

using System.Collections.Generic;
using System.Linq;

namespace NET.W._2019.Titkov._01
{
    /// <summary>
    /// This class does test of sorting.
    /// </summary>
    static class Test
    {
        /// <summary>
        /// Compares custom sorting algorithm result, with system build sorting algorithm result.
        /// </summary>
        /// <returns>
        /// "Test passed" or "Test failed" string.
        /// </returns>
        public static string TestOfSortingResult(List<int> sorted, List<int> unsorted)
        {
            unsorted.Sort();

            return sorted.SequenceEqual(unsorted) ? "Test passed" : "Test failed";
        }
    }
}
