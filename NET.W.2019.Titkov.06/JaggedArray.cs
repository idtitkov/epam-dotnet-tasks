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
        /// Sorts two-dimensional array according to sum of elements in a row.
        /// </summary>
        /// <param name="arr">Two-dimensional array to sort.</param>
        public static void SortBySumOfElementsInARow(int[][] arr)
        {
            //// Temporary array(list) to hold values.
            List<int> sumsOfElementsInARows = new List<int>(arr.Length);

            //// Finding sums of elements in array and put it in a temporary array.
            for (int i = 0; i < arr.Length; i++)
            {
                sumsOfElementsInARows.Add(0);
                for (int j = 0; j < arr[i].Length; j++)
                {
                    sumsOfElementsInARows[i] += arr[i][j];
                }
            }

            //// Bubble sort, according to values in temporary array.
            BubbleSortByAscWithTemplate(ref arr, ref sumsOfElementsInARows);
        }

        /// <summary>
        /// Sorts two-dimensional array according to maximum value in a row.
        /// </summary>
        /// <param name="arr">Two-dimensional array to sort.</param>
        public static void SortByMaxInRow(int[][] arr)
        {
            //// Temporary array(list) to hold values.
            List<int> maxElementInARow = new List<int>(arr.Length);

            //// Finding maximal element in a row and put it in a temporary array.
            for (int i = 0; i < arr.Length; i++)
            {
                maxElementInARow.Add(int.MinValue);
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (maxElementInARow[i] < arr[i][j])
                    {
                        maxElementInARow[i] = arr[i][j];
                    }
                }
            }

            //// Bubble sort, according to values in temporary array.
            BubbleSortByAscWithTemplate(ref arr, ref maxElementInARow);
        }

        /// <summary>
        /// Sorts two-dimensional array according to minimum value in a row.
        /// </summary>
        /// <param name="arr">Two-dimensional array to sort.</param>
        public static void SortByMinInRow(int[][] arr)
        {
            //// Temporary array(list) to hold values.
            List<int> minElementInARow = new List<int>(arr.Length);

            //// Finding minimal element in a row and put it in a temporary array.
            for (int i = 0; i < arr.Length; i++)
            {
                minElementInARow.Add(int.MaxValue);
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (minElementInARow[i] > arr[i][j])
                    {
                        minElementInARow[i] = arr[i][j];
                    }
                }
            }

            //// Bubble sort, according to values in temporary array.
            BubbleSortByAscWithTemplate(ref arr, ref minElementInARow);
        }

        /// <summary>
        /// Writes two-dimensional array to console.
        /// </summary>
        /// <param name="arr">Two-dimensional array to print.</param>
        public static void PrintArray(int[][] arr)
        {
            foreach (var row in arr)
            {
                foreach (var element in row)
                {
                    Console.Write(element + " ");
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Bubble soft method for internal use.
        /// </summary>
        /// <param name="arr">Two-dimensional array to sort rows.</param>
        /// <param name="template">Template to sort like array.</param>
        private static void BubbleSortByAscWithTemplate(ref int[][] arr, ref List<int> template)
        {
            for (int i = 0; i < template.Count; i++)
            {
                for (int j = 0; j < template.Count - 1; j++)
                {
                    if (template[j] > template[j + 1])
                    {
                        //// Swap for value type
                        int tempInt = template[j + 1];
                        template[j + 1] = template[j];
                        template[j] = tempInt;

                        //// Swap for ref type.
                        Swap(ref arr[j], ref arr[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Swap for reference type variables.
        /// </summary>
        /// <typeparam name="T">Reference type.</typeparam>
        /// <param name="lhs">Variable to swap with.</param>
        /// <param name="rhs">Variable to swap with.</param>
        private static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
    }
}