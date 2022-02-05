using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSum
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        // O(n) time | O(d) space - where n is the total number of elements
        // including sub-elements, and d is the greatest depth of "special"
        public static int ProductSum(List<object> array)
        {
            return productSumHelper(array, 1);
        }

        public static int productSumHelper(List<object> array, int multiplier)
        {
            int sum = 0;
            foreach (object el in array)
            {
                if (el is IList<object>)
                {
                    sum += productSumHelper((List<object>)el, multiplier + 1);
                }
                else
                {
                    sum += (int)el;
                }
            }
            return sum * multiplier;
        }
    }
}
