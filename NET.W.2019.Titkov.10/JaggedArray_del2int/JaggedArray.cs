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
        public delegate int DelegateComparer(int[] x, int[] y);

        /// <summary>
        /// Sorts two-dimensional array using IComparer.Sort method.
        /// </summary>
        /// <param name="arr">Array to sort.</param>
        /// <param name="comparer">IComparer.Sort delegate.</param>
        public static void Sort(this int[][] arr, DelegateComparer comparer)
        {
            _ = arr ?? throw new ArgumentNullException(nameof(arr), "Array should not be null.");
            _ = comparer ?? throw new ArgumentNullException(nameof(comparer), "Comparer should not be null.");

            // Call method with interface.
            Sort(arr, new Adapter(comparer));
        }

        /// <summary>
        /// Writes two-dimensional array to console.
        /// </summary>
        /// <param name="arr">Two-dimensional array to print.</param>
        public static void PrintArray(this int[][] arr)
        {
            _ = arr ?? throw new ArgumentNullException(nameof(arr), "Array should not be null.");

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
        /// Sorts two-dimensional array using IComparer.
        /// </summary>
        /// <param name="arr">Array to sort.</param>
        /// <param name="comparer">IComparer.</param>
        private static void Sort(int[][] arr, IComparer<int[]> comparer)
        {
            _ = arr ?? throw new ArgumentNullException(nameof(arr), "Array should not be null.");
            _ = comparer ?? throw new ArgumentNullException(nameof(comparer), "Comparer should not be null.");

            // Call standart Array.Sort method.
            Array.Sort(arr, comparer);
        }

        /// <summary>
        /// Adapter to use DelegateComparer as IComparer.
        /// </summary>
        private class Adapter : IComparer<int[]>
        {
            private readonly DelegateComparer comparer;

            public Adapter(DelegateComparer comparer)
            {
                _ = comparer ?? throw new ArgumentNullException(nameof(comparer), "Comparer should not be null.");

                this.comparer = comparer;
            }

            public int Compare(int[] x, int[] y)
            {
                return comparer.Invoke(x, y);
            }
        }
    }
}