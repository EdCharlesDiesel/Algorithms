using System.Collections.Generic;

namespace StringSearching.BoyerMooreHorspool
{
    class BadMatchTable
    {
        private readonly int defaultValue;
        private readonly Dictionary<int, int> distances;

        public BadMatchTable(string pattern)
        {
            defaultValue = pattern.Length;
            distances = new Dictionary<int, int>();

            for (int i = 0; i < pattern.Length - 1; i++)
            {
                distances[pattern[i]] = pattern.Length - i - 1;
            }
        }

        public int this[int index]
        {
            get
            {
                return distances.GetValueOrDefault(index, defaultValue);
            }
        }    
    }
}
