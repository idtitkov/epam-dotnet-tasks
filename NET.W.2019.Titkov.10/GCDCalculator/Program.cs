using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatestCommonDivisor
{
    /// <summary>
    /// Main program class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Program entry point.
        /// </summary>
        public static void Main(string[] args)
        {
            //// Array to analyze. More in tests.
            int[] arr = new int[] { 300181, 223744, -38, 79235168 };

            int timeByStopwatch;
            int timeByDateTime;

            // Writing results.
            Console.Write("Numbers to calculate greatest common divisor: ");
            WriteArrayToConsole(arr);
            Console.WriteLine();

            Console.Write("Euclid algorithm work result: ");
            Console.WriteLine(GCDCalculator.GCDArrayCalculator(GCDCalculator.Euclid, out timeByStopwatch, out timeByDateTime, arr));
            Console.WriteLine("Time Taken: {0}ms by Stopwatch, {1}ms by DateTime", timeByStopwatch, timeByDateTime);
            Console.WriteLine();

            Console.Write("Binary Stein algorithm work result: ");
            Console.WriteLine(GCDCalculator.GCDArrayCalculator(GCDCalculator.Stein, out timeByStopwatch, out timeByDateTime, arr));
            Console.WriteLine("Time Taken: {0}ms by Stopwatch, {1}ms by DateTime", timeByStopwatch, timeByDateTime);
            Console.WriteLine();

            Console.ReadKey();
        }

        /// <summary>
        /// Writes numbers to console.
        /// </summary>
        /// <param name="arr">Numbers or array</param>
        private static void WriteArrayToConsole(params int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}
