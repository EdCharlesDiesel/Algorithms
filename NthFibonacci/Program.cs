using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NthFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        // O(2^n) time | O(n) space
        public static int GetNthFib(int n)
        {
            if (n == 2)
            {
                return 1;
            }
            else if (n == 1)
            {
                return 0;
            }
            else
            {
                return GetNthFib(n - 1) + GetNthFib(n - 2);
            }
        }

        // O(n) time | O(n) space
        public static int GetNthFib2(int n)
        {
            Dictionary<int, int> memoize = new Dictionary<int, int>();
            memoize.Add(1, 0);
            memoize.Add(2, 1);
            return GetNthFib3(n, memoize);
        }

        public static int GetNthFib3(int n, Dictionary<int, int> memoize) 
        {
            if (memoize.ContainsKey(n))
            {
                return memoize[n];
            } else {
                memoize.Add(n, GetNthFib3(n - 1, memoize) + GetNthFib3(n - 2, memoize);
            return memoize[n];
             }
        }

        // O(n) time | O(1) space
        public static int GetNthFib4(int n)
        {
            int[] lastTwo = { 0, 1 };
            int counter = 3;
            while (counter <= n)
            {
                int nextFib = lastTwo[0] + lastTwo[1];
                lastTwo[0] = lastTwo[1];
                lastTwo[1] = nextFib;
                counter++;
            }
            return n > 1 ? lastTwo[1] : lastTwo[0];
        }
    }
}
