/*
NET.W.2019.Titkov.02

4. Реализовать метод FilterDigit который принимает список целых чисел и фильтрует список,
таким образом, чтобы на выходе остались только числа, содержащие заданную цифру.
LINQ не использовать! Например, для цифры 7, FilterDigit (7,1,2,3,4,5,6,7,68,69,70, 15,17) -> {7, 70, 17}. 

Ivan Titkov
*/

using System;
using System.Collections.Generic;

namespace NET.W._2019.Titkov._02
{
    /// <summary>
    /// Main program class.
    /// </summary>
    class Filter
    {
        /// <summary>
        /// Program entry point.
        /// </summary>
        static void Main(string[] args)
        {
            // Requesting for a count of list.
            int countOfList;
            do
            {
                // Repeat until input is a number.
                Console.Write("How many numbers do you want to enter?: ");
            } while (!int.TryParse(Console.ReadLine(), out countOfList) || countOfList < 0);

            // Adding numbers fo list.
            List<int> numbersToFilter = new List<int>();
            int numberToFilter;
            for (int i = 0; i < countOfList; i++)
            {
                do
                {
                    // Repeat until input is a number.
                    Console.Write("Enter number: ");

                } while (!int.TryParse(Console.ReadLine(), out numberToFilter));
                numbersToFilter.Add(numberToFilter);
            }

            // Requesting for a filter digit.
            int filterDigit;
            do
            {
                // Repeat until input is a number.
                Console.Write("Enter a filter digit: ");
            } while (!int.TryParse(Console.ReadLine(), out filterDigit) || filterDigit < 0 || filterDigit > 9);

            // Filtering numbers.
            numbersToFilter = NumberUtils.FilterDigit(numbersToFilter, filterDigit);

            // Writing results to a console.            
            Console.Write("\nFiltering result: ");
            foreach (var item in numbersToFilter)
            {
                Console.Write(item + " ");
            }

            // Waiting for any key to be pressed.
            Console.WriteLine();
            Console.ReadKey();
        }
    }

    /// <summary>
    /// Contains methods to work with numbers.
    /// </summary>
    static class NumberUtils
    {
        /// <summary>
        /// Filters list of ints by deleting values not contain filter digit.
        /// </summary>
        /// <param name="unfilteredList">List to be filtered</param>
        /// <param name="digitToFilter">Filter digit value</param>
        /// <returns>Filtered int list</returns>
        public static List<int> FilterDigit(List<int> unfilteredList, int digitToFilter)
        {
            List<int> filteredList = new List<int>();

            // Searchimg for filter digit by analyzing remainder after dividing number by 10.
            for (int i = 0; i < unfilteredList.Count; i++)
            {
                while (unfilteredList[i] > 0)
                {
                    if (unfilteredList[i] % 10 == digitToFilter)
                    {
                        filteredList.Add(unfilteredList[i]);
                        break;
                    }
                    unfilteredList[i] = unfilteredList[i] / 10;
                }
            }

            // Return result.
            return filteredList;
        }
    }
}