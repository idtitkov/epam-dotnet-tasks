using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatestCommonDivisor
{
    /// <summary>
    /// Provides methods for calculating greatest common divisor.
    /// </summary>
    public static class GCDCalculator
    {
        /// <summary>
        /// Greatest common divisor calculation by Euclid algorithm.
        /// </summary>
        /// <param name="array">Numbers to analyze</param>
        /// <returns></returns>
        public static int Euclid(params int[] array)
        {
            //// Argumen Null Exception
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            //// Deleting all zeroes.
            array = array.Where(val => val != 0).ToArray();

            //// While there are at least 2 numbers in array to analyze.
            while (array.Length >= 2)
            {
                //// Removing influence of negative numbers.
                array[0] = Math.Abs(array[0]);
                array[1] = Math.Abs(array[1]);

                //// Run Euclid algorithm.
                while (array[0] != array[1])
                {
                    if (array[0] > array[1])
                    {
                        array[0] = array[0] - array[1];
                    }
                    else
                    {
                        array[1] = array[1] - array[0];
                    }
                }

                //// Writing found GCD to the 2nd elenet of the array.
                array[1] = array[0];
                //// Cut 1st element of the array, to get new array with GCD as a 1st element.
                array = array.Skip(1).ToArray();
                //// Recursion call with GDC found instead of first two values in initial array.
                return Euclid(array);
            }

            //// Return answer, where there are only one number in array left. 
            return array[0];
        }

        /// <summary>
        /// Greatest common divisor calculation by Stein algorithm.
        /// </summary>
        /// <param name="array">Numbers to analyze</param>
        public static int Stein(params int[] array)
        {
            //// Argumen Null Exception
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            //// Removing influence of negative numbers.
            array[0] = Math.Abs(array[0]);
            array[1] = Math.Abs(array[1]);

            //// If there are more than 2 values left in array, make recursion call without 1st array value.
            if (array.Length > 2)
            {
                Stein(array.Skip(1).ToArray());
            }

            //// Else proceed basic Stein algorithm for 2 numbers.
            if (array[0] == array[1])
            {
                return array[0];
            }

            if (array[0] == 0)
            {
                return array[1];
            }

            if (array[1] == 0)
            {
                return array[0];
            }

            if ((~array[0] & 1) != 0)
            {
                if ((array[1] & 1) != 0)
                {
                    return Stein(array[0] >> 1, array[1]);
                }
                else
                {
                    return Stein(array[0] >> 1, array[1] >> 1) << 1;
                }
            }

            if ((~array[1] & 1) != 0)
            {
                return Stein(array[0], array[1] >> 1);
            }

            if (array[0] > array[1])
            {
                return Stein((array[0] - array[1]) >> 1, array[1]);
            }

            return Stein((array[1] - array[0]) >> 1, array[0]);
        }

        /// <summary>
        /// Euclid algorithm time counting using DateTime.
        /// </summary>
        /// <param name="array">Numbers to analyze</param>
        public static void EuclidTimeTaken(params int[] array)
        {
            DateTime start = DateTime.Now;

            Euclid(array);

            DateTime end = DateTime.Now;
            TimeSpan timeDiff = end - start;
            Console.WriteLine("Euclid time taken: " + Convert.ToInt32(timeDiff.TotalMilliseconds) + " miliseconds");
        }

        /// <summary>
        /// Stein algorithm time counting using Stopwatch.
        /// </summary>
        /// <param name="array">Numbers to analyze</param>
        public static void SteinTimeTaken(params int[] array)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Stein(array);

            stopwatch.Stop();
            TimeSpan stopwatchElapsed = stopwatch.Elapsed;
            Console.WriteLine("Stein time taken: " + Convert.ToInt32(stopwatchElapsed.TotalMilliseconds) + " miliseconds");
        }
    }
}