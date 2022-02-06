using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        // O(log(n)) time | O(log(n)) space
        public static int BinarySearch(int[] array, int target)
        {
            return BinarySearch(array, target, 0, array.Length - 1);
        }
        public static int BinarySearch(int[] array, int target, int left, int right)
        {
            if (left > right)
            {
                return -1;
            }
            int middle = (left + right) / 2;
            int potentialMatch = array[middle];
            if (target == potentialMatch)
            {
                return middle;
            }
            else if (target < potentialMatch)
            {
                return BinarySearch(array, target, left, middle - 1);
            }
            else
            {
                return BinarySearch(array, target, middle + 1, right);
            }
        }
    }
}
