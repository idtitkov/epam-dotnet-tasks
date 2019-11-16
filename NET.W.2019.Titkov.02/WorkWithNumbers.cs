/*
NET.W.2019.Titkov.02

2) Реализовать метод FindNextBiggerNumber, который принимает положительное целое число и возвращает
ближайшее наибольшее целое, состоящее из цифр исходного числа, и -1 (null), если такого числа не существует.

Ivan Titkov
*/

using System;
using System.Collections.Generic;

namespace NET.W._2019.Titkov._02
{
    /// <summary>
    /// Main program class.
    /// </summary>
    class WorkWithNumbers
    {
        /// <summary>
        /// Program entry point.
        /// </summary>
        static void Main(string[] args)
        {
            // Requesting for a number to analyze.
            int numberToAnalyze;
            do
            {
                // Repeat until input is a number.
                Console.Write("Enter a positive number: ");
            } while (!int.TryParse(Console.ReadLine(), out numberToAnalyze) || numberToAnalyze < 0);

            // Calculating "nextBiggerNumber".
            int nextBiggerNumber;
            nextBiggerNumber = NumberUtils.FindNextBiggerNumber(numberToAnalyze);

            // Writing result to console.
            Console.WriteLine("Next bigger number is: {0}", nextBiggerNumber);

            // Waiting for any key to be pressed.
            Console.ReadKey();
        }
    }

    /// <summary>
    /// Contains methods to work with numbers.
    /// </summary>
    static class NumberUtils
    {
        // All combinations found as a strings.
        private static List<string> AllCombinationsStrings = new List<string>();
        // All combinations found as an ints.
        private static List<int> AllCombinationsInts = new List<int>();

        /// <summary>
        /// Method to find closest bigger number with the same digits as param.
        /// </summary>
        /// <param name="num">Number to analyze</param>
        /// <returns>Returns next bigger number with the same digits, or -1 if not found.</returns>
        public static int FindNextBiggerNumber(int num)
        {
            // Default return value.
            int nextBiggerNumber = -1;

            // Finding all digits combinations as a list of strings.
            FindAllCombinations(IntToCharArray(num));
            // Converting list of string results to list of ints.
            AllCombinationsInts = AllCombinationsStrings.ConvertAll(s => int.Parse(s));

            // Finding closest bigger number, if exists.
            AllCombinationsInts.Sort();
            foreach (int firstBiggerNumber in AllCombinationsInts)
            {
                if (firstBiggerNumber > num)
                {
                    nextBiggerNumber = firstBiggerNumber;
                    break;
                }
            }

            // Returning found value, or -1 if not exists.
            return nextBiggerNumber;
        }

        /// <summary>
        /// Finds all combinations of chars in array and adds it to string list.
        /// </summary>
        /// <param name="list">Char array to analyze</param>
        private static void FindAllCombinations(char[] list)
        {
            int x = list.Length - 1;
            FindAllCombinations(list, 0, x);
        }

        /// <summary>
        /// Recorsive call of FindAllCombinations function.
        /// </summary>
        /// <param name="list">Char array to analyze</param>
        /// <param name="d">Recursion depth</param>
        /// <param name="m">Max depth</param>
        private static void FindAllCombinations(char[] list, int d, int m)
        {
            if (d == m)
            {
                AllCombinationsStrings.Add(new string(list));
            }
            else
                for (int i = d; i <= m; i++)
                {
                    Swap(ref list[d], ref list[i]);
                    FindAllCombinations(list, d + 1, m);
                    Swap(ref list[d], ref list[i]);
                }
        }

        /// <summary>
        /// Swaps two char references.
        /// </summary>
        /// <param name="a">char to swap</param>
        /// <param name="b">char to swap</param>
        private static void Swap(ref char a, ref char b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Converts int to array of chars.
        /// </summary>
        /// <param name="num">Int32 number.</param>
        /// <returns>Array of chars.</returns>
        private static char[] IntToCharArray(int num)
        {
            return num.ToString().ToCharArray();
        }
    }
}