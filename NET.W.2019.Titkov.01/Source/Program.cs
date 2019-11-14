using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        static void Main(string[] args)
        {
            List<int> unsortedList = new List<int>();
            List<int> sortedList;
            int listSize = 0;

            var rand = new Random();

            while (listSize < 2)
            {
                Console.Write("How many numbers do you want to generate (not less than 2)?: ");
                listSize = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < listSize; i++)
            {
                unsortedList.Add(rand.Next(listSize / -2, listSize));
            }
            WriteListToConsole(unsortedList);

            Console.Write("\nHow do you want to sort it?\n1.Quick sort.\n2.Merge sort.\nYour choice: ");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                // Quick sort
                case 1:
                    sortedList = new List<Int32>(unsortedList);
                    QuickSort.Sort(sortedList, 0, sortedList.Count);
                    WriteListToConsole(sortedList);
                    // Write test result to console
                    Console.WriteLine(Test.TestOfSortingResult(sortedList, unsortedList));
                    break;
                // Merge sort
                case 2:
                    sortedList = MergeSort.Sort(unsortedList);
                    WriteListToConsole(sortedList);
                    Console.WriteLine(Test.TestOfSortingResult(sortedList, unsortedList));
                    break;
                default:
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
    }
}