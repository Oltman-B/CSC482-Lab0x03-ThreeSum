using System;
using System.Collections.Generic;
using System.Text;

namespace Lab0x03
{
    public static class ListExtensions
    {
        public static int BinarySearch(this List<int> @this, int target)
        {
            return BinarySearch(@this, target, 0, @this.Count - 1);
        }

        public static int BinarySearch(List<int> list, int target, int left, int right)
        {
            while (left <= right)
            {
                int middle = (left + right) / 2;
                int match = list[middle];

                if (target == match)
                {
                    return middle;
                }
                else if (target < match)
                {
                    right = --middle;
                }
                else
                {
                    left = ++middle;
                }
            }

            return -1;
        }
    }
}
