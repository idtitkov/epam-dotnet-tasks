using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Titkov._01
{
    /// <summary>
    /// This class does "Quick sort".
    /// </summary>
    static class QuickSort
    {
        public static void Sort(List<int> list, int left, int right)
        {
            if (list == null || list.Count <= 1)
                return;

            if (left < right)
            {
                int pivotIdx = Partition(list, left, right);
                //Console.WriteLine("MQS " + left + " " + right);
                //DumpList(list);
                Sort(list, left, pivotIdx - 1);
                Sort(list, pivotIdx, right);
            }
        }

        private static int Partition(List<int> list, int left, int right)
        {
            int start = left;
            int pivot = list[start];
            left++;
            right--;

            while (true)
            {
                while (left <= right && list[left] <= pivot)
                    left++;

                while (left <= right && list[right] > pivot)
                    right--;

                if (left > right)
                {
                    list[start] = list[left - 1];
                    list[left - 1] = pivot;

                    return left;
                }

                int temp = list[left];
                list[left] = list[right];
                list[right] = temp;

            }
        }
    }
}

