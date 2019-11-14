/*
Day 1 Task
Реализовать методы быстрой сортировки и сортировки слиянием для целочисленного массива.
Протестировать работу методов в консольном приложении или с помощью модульного тестирования.

Ivan Titkov 14.11.2019
*/

using System;
using System.Collections.Generic;

namespace NET.W._2019.Titkov._01
{
    /// <summary>
    /// Main program class.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Program entry point.
        /// </summary>
        public static void Main(string[] args)
        {
            // List of values to sort.
            List<int> unsortedList = new List<int>();
            // Result of sorting.
            List<int> sortedList;
            // Quantity of values to sort.
            int listSize;
            // Variable for random number generation.
            var rand = new Random();
            // Switch-case variable
            int choice;

            // Values quantity request.
            do
            {
                // Repeat until input is a number less than 2.
                Console.Write("How many numbers do you want to generate (not less than 2)?: ");
            } while (!int.TryParse(Console.ReadLine(), out listSize) || listSize < 2);

            // Fill list with random values.
            for (int i = 0; i < listSize; i++)
            {
                unsortedList.Add(rand.Next(listSize / -2, listSize / 2));
            }

            // Write generated values to console.
            WriteListToConsole(unsortedList);

            // Sorting algorithm choosing menu.
            do
            {
                // Repeat until input is a number.
                Console.Write($"\nHow do you want to sort it?" +
                    $"\n{(int)SortingAlgorithms.QuickSort}. Quick sort." +
                    $"\n{(int)SortingAlgorithms.MergeSort}. Merge sort." +
                    $"\nOther = Exit." +
                    $"\nYour choice: ");
            } while (!int.TryParse(Console.ReadLine(), out choice));

            switch (choice)
            {
                // Quick sort
                case (int)SortingAlgorithms.QuickSort:
                    sortedList = new List<int>(unsortedList);
                    QuickSort.Sort(sortedList, 0, sortedList.Count);
                    WriteListToConsole(sortedList);
                    // Write test result to console.
                    Console.WriteLine(Test.TestOfSortingResult(sortedList, unsortedList) + "\n");
                    break;
                // Merge sort
                case (int)SortingAlgorithms.MergeSort:
                    sortedList = MergeSort.Sort(unsortedList);
                    // Write sorting result to console.
                    WriteListToConsole(sortedList);
                    // Write test result to console.
                    Console.WriteLine(Test.TestOfSortingResult(sortedList, unsortedList) + "\n");
                    break;
                default:
                    Console.WriteLine("Exit.\n");
                    break;
            }
        }

        /// <summary>
        /// This method writes list to console.
        /// </summary>
        private static void WriteListToConsole(List<int> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Enum with sorting algorithms available.
        /// </summary>
        private enum SortingAlgorithms
        {
            QuickSort = 1,
            MergeSort = 2
        }
    }
}