/*
NET.W.2019.Titkov.02

1) Даны два целых знаковых четырех байтовых числа и две позиции битов i и j (i<j).
Реализовать алгоритм InsertNumber вставки битов с j-ого по i-ый бит одного числа в другое так,
чтобы биты второго числа занимали позиции с бита j по бит i (биты нумеруются справа налево).

Ivan Titkov
*/

using System;

namespace NET.W._2019.Titkov._02
{
    /// <summary>
    /// Main program class.
    /// </summary>
    class BitwiseAndShiftOperators
    {
        /// <summary>
        /// Program entry point.
        /// </summary>
        static void Main(string[] args)
        {
            // Input values.
            int numberSource;
            int numberIn;
            int startPosition;
            int endPosition;

            #region Requesting for inputs.
            // Requesting for numberSource value.
            do
            {
                // Repeat until input is a number.
                Console.Write("Enter Source number: ");
            } while (!int.TryParse(Console.ReadLine(), out numberSource));

            // Requesting for numberIn value.
            do
            {
                // Repeat until input is a number.
                Console.Write("Enter Insert number: ");

            } while (!int.TryParse(Console.ReadLine(), out numberIn));

            // Requesting for startPosition index value.
            do
            {
                // Repeat until input is a number.
                Console.Write("Enter start position index for bits insertion: ");

            } while (!int.TryParse(Console.ReadLine(), out startPosition));

            // Requesting for endPosition index value.
            do
            {
                // Repeat until input is a number.
                Console.Write("Enter end position index for bits insertion (more than start): ");

            } while (!int.TryParse(Console.ReadLine(), out endPosition) || endPosition < startPosition);
            #endregion

            // Writing inputs to console.
            Console.WriteLine("\nSource number is " + numberSource);
            BinaryUtils.WriteAs32BitBinary(numberSource);

            Console.WriteLine("\nInsertion number is " + numberIn);
            BinaryUtils.WriteAs32BitBinary(numberIn);

            // Insertion result.
            int result;
            result = BinaryUtils.InsertNumber(numberSource, numberIn, startPosition, endPosition);

            // Writing result to console.
            Console.WriteLine("\nResult of insertion is " + result);
            BinaryUtils.WriteAs32BitBinary(result);

            // Waiting for input to exit.
            Console.ReadKey();
        }
    }

    /// <summary>
    /// Contains methods for binary operations.
    /// </summary>
    static class BinaryUtils
    {
        // Binary numeral system constant value;
        private const int BINARY_NUMERAL_SYSTEM_BASE = 2;

        /// <summary>
        /// Inserts one number bits instead of another number bits according to particular offsets.
        /// </summary>
        /// <param name="numberSource">Source number.</param>
        /// <param name="numberIn">Number to insert in source number.</param>
        /// <param name="startPosition">Start index of number insertion (i).</param>
        /// <param name="endPosition">Last index of number insertion (j).</param>
        /// <returns>Int32 number, merged from two numbers, according to particular offsets.</returns>
        public static int InsertNumber(int numberSource, int numberIn, int startPosition, int endPosition)
        {
            // Throwing an exception if startPosition index is more than endPosition index;
            if (startPosition > endPosition)
            {
                throw new ArgumentException();
            }

            // Calculating mask for "numberSource" variable.
            int numberSourceMask = (int)(Math.Pow(BINARY_NUMERAL_SYSTEM_BASE, endPosition - startPosition + 1) - 1);
            numberSourceMask = numberSourceMask << startPosition;
            numberSourceMask = ~numberSourceMask;
            // Applying "numberSourceMask" on "numberSource".
            numberSource = numberSource & numberSourceMask;

            // Calculating mask for "numberIn" variable.
            int numberInMask = (int)(Math.Pow(BINARY_NUMERAL_SYSTEM_BASE, endPosition - startPosition + 1) - 1);
            // Applying "numberInMask" on "numberIn".
            numberIn = numberIn & numberInMask;
            // Shifting "numberIn" variable.
            numberIn = numberIn << startPosition;

            // Returning bit inserting operation result.
            return numberIn | numberSource;
        }

        /// <summary>
        /// Writes Int32 to console in binary format as a string.
        /// </summary>
        /// <param name="number">Int32 to to wtite in binary format.</param>
        public static void WriteAs32BitBinary(int number)
        {
            Console.WriteLine(Convert.ToString(number, BINARY_NUMERAL_SYSTEM_BASE).PadLeft(32, '0'));
        }
    }
}