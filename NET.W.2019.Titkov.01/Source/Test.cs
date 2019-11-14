using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Titkov._01
{
    /// <summary>
    /// This class does test of sorting.
    /// </summary>
    static class Test
    {
        public static string TestOfSortingResult(List<int> sorted, List<int> unsorted)
        {
            unsorted.Sort();

            return sorted.SequenceEqual(unsorted) ? "Test passed" : "Test failed";
        }
    }
}
