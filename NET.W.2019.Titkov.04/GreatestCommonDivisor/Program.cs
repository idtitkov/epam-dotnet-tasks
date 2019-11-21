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
            int[] arr = new int[] { 300181, 223744, 38 };

            // Writing results.
            Console.Write("Numbers to calculate greatest common divisor: ");
            WriteArrayToConsole(arr);
            Console.WriteLine();

            GCDCalculator.EuclidTimeTaken(arr);
            Console.Write("Euclid algorithm work result: ");
            Console.WriteLine(GCDCalculator.Euclid(arr));
            Console.WriteLine();

            GCDCalculator.SteinTimeTaken(arr);
            Console.Write("Binary Stein algorithm work result: ");
            Console.WriteLine(GCDCalculator.Stein(arr));
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
