using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Titkov._06
{
    public class CompareByMaxElements : IComparer<int[]>
    {
        /// <summary>
        /// Compares two arrays by their max element value.
        /// </summary>
        /// <param name="x">First array.</param>
        /// <param name="y">Second array.</param>
        /// <returns>Negative number if x less than y, positive if x more than y, zero if equals.</returns>
        public int Compare(int[] x, int[] y)
        {
            _ = x ?? throw new ArgumentNullException(nameof(x), "Array x should not be null.");
            _ = y ?? throw new ArgumentNullException(nameof(y), "Array y should not be null.");

            return x.Max() - y.Max();
        }
    }
}
