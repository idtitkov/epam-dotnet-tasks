using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Titkov._06
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[][] testArray = new int[][]
            {
                new int[] { 1, 3, 5, 7, 9 },
                new int[] { 11, 22 },
                new int[] { 0, 2, 4, 6 },
                new int[] { 2, 25, 99 }
            };

            testArray.PrintArray();

            testArray.Sort(new CompareByMaxElements().Compare);
            testArray.PrintArray();

            testArray.Sort(new CompareByMinElements().Compare);
            testArray.PrintArray();

            testArray.Sort(new CompareBySumOfElements().Compare);
            testArray.PrintArray();
        }
    }
}
