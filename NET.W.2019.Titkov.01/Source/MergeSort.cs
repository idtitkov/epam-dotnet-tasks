/*
Day 1 Task
Merge sort algorithm.

Ivan Titkov 14.11.2019
*/

using System.Collections.Generic;
using System.Linq;

namespace NET.W._2019.Titkov._01
{
    /// <summary>
    /// This class does "Merge sort".
    /// </summary>
    static class MergeSort
    {
        /// <summary>
        /// Sorts list with "Merge sort" algorithm.
        /// </summary>
        /// <returns>
        /// Sorted list.
        /// </returns>
        public static List<int> Sort(List<int> unsorted)
        {
            if (unsorted.Count <= 1)
                return unsorted;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = unsorted.Count / 2;
            for (int i = 0; i < middle; i++)  //Dividing the unsorted list
            {
                left.Add(unsorted[i]);
            }
            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = Sort(left);
            right = Sort(right);
            return Merge(left, right);
        }

        /// <summary>
        /// Service method to make "Merge sort".
        /// </summary>
        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())  //Comparing First two elements to see which is smaller
                    {
                        result.Add(left.First());
                        left.Remove(left.First());      //Rest of the list minus the first element
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());

                    right.Remove(right.First());
                }
            }
            return result;
        }
    }
}
