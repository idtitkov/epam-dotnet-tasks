using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Titkov._06
{
    /// <summary>
    /// Utilities to work with jagged arrays.
    /// </summary>
    public static class JaggedArray
    {
        /// <summary>
        /// Delegate refers to IComparer.Sort method.
        /// </summary>
        /// <param name="x">First array.</param>
        /// <param name="y">Second array.</param>
        /// <returns>Negative number if x less than y, positive if x more than y, zero if equals.</returns>
        private delegate int DelegateComparer(int[] x, int[] y);

        /// <summary>
        /// Sorts two-dimensional array using IComparer.
        /// </summary>
        /// <param name="arr">Array to sort.</param>
        /// <param name="comparer">IComparer.</param>
        public static void Sort(this int[][] arr, IComparer<int[]> comparer)
        {
            _ = arr ?? throw new ArgumentNullException(nameof(arr), "Array should not be null.");
            _ = comparer ?? throw new ArgumentNullException(nameof(comparer), "Comparer should not be null.");

            // Call method with delegate.
            Sort(arr, comparer.Compare);
        }

        /// <summary>
        /// Writes two-dimensional array to console.
        /// </summary>
        /// <param name="arr">Two-dimensional array to print.</param>
        public static void PrintArray(this int[][] arr)
        {
            foreach (var row in arr)
            {
                foreach (var element in row)
                {
                    Console.Write(element + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Sorts two-dimensional array using IComparer.Sort method.
        /// </summary>
        /// <param name="arr">Array to sort.</param>
        /// <param name="comparer">IComparer.Sort delegate.</param>
        private static void Sort(int[][] arr, DelegateComparer comparer)
        {
            _ = arr ?? throw new ArgumentNullException(nameof(arr), "Array should not be null.");
            _ = comparer ?? throw new ArgumentNullException(nameof(comparer), "Comparer should not be null.");

            // Classic bubble sort.
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    // Delegate invoke.
                    if (comparer.Invoke(arr[j], arr[j + 1]) > 0)
                    {
                        var temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
    }
}
