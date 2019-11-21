using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleToBinary
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
            //// Requesting number to convert.
            double number;
            do
            {
                //// Repeat until input is a number.
                Console.Write("Enter float point number to convert: ");
            }
            while (!double.TryParse(Console.ReadLine(), out number));

            //// Writing conversion result.
            Console.Write("Entered number in binary: ");
            Console.WriteLine(BinaryConverter.DoubleToBinary(number));

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
