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
        public delegate int GCDAlgorithm(int a, int b);

        /// <summary>
        /// Greatest common divisor calculation by Euclid algorithm.
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Greatest common divisor of first and second number</returns>
        public static int Euclid(int a, int b)
        {
            //// Removing influence of negative numbers.
            a = Math.Abs(a);
            b = Math.Abs(b);

            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }

            return a;
        }

        /// <summary>
        /// Greatest common divisor calculation by Stein algorithm.
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Greatest common divisor of first and second number</returns>
        public static int Stein(int a, int b)
        {
            //// Removing influence of negative numbers.
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a == b)
            {
                return a;
            }

            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            if ((~a & 1) != 0)
            {
                if ((b & 1) != 0)
                {
                    return Stein(a >> 1, b);
                }
                else
                {
                    return Stein(a >> 1, b >> 1) << 1;
                }
            }

            if ((~b & 1) != 0)
            {
                return Stein(a, b >> 1);
            }

            if (a > b)
            {
                return Stein((a - b) >> 1, b);
            }

            return Stein((b - a) >> 1, a);
        }

        /// <returns>Greatest common divisor of an array.</returns>
        /// <summary>
        /// Universal GCD calculator for array.
        /// </summary>
        /// <param name="algGCD">GCD Algorithm</param>
        /// <param name="swMiliSec">Tike taken (Stopwatch calculation) in milliseconds.</param>
        /// <param name="dtMiliSec">Tike taken (DateTime calculation) in milliseconds.</param>
        /// <param name="arr">Array to analyze</param>
        /// <returns></returns>
        public static int GCDArrayCalculator(GCDAlgorithm algGCD, out int stopTatchMs, out int dateTimeMs, params int[] arr)
        {
            _ = algGCD ?? throw new ArgumentNullException(nameof(algGCD), "Algorithm should not be null");
            _ = arr ?? throw new ArgumentNullException(nameof(arr), "Numbers array should not be null");

            //// Deleting all zeroes.
            var arrToAnalyze = arr.Where(val => val != 0).ToArray();

            if (arrToAnalyze.Length < 2)
            {
                throw new ArgumentException("Less than 2 numbers provided. Zeroes are not accepted.", nameof(arr));
            }

            //// Time taken calculation. Start.
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            DateTime start = DateTime.Now;

            //// Calculation algorithm call.
            var result = algGCD(arrToAnalyze[0], arrToAnalyze[1]);
            for (int i = 2; i < arrToAnalyze.Length; i++)
            {
                result = algGCD(result, arrToAnalyze[i]);
            }

            //// Time taken calculation. Stop.
            stopwatch.Stop();
            TimeSpan stopwatTimeSpan = stopwatch.Elapsed;
            stopTatchMs = Convert.ToInt32(stopwatTimeSpan.TotalMilliseconds);

            DateTime end = DateTime.Now;
            TimeSpan dateTimeSpan = end - start;
            dateTimeMs = Convert.ToInt32(dateTimeSpan.TotalMilliseconds);

            return result;
        }
    }
}