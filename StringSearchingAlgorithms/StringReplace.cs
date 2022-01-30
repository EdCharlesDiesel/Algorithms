using System.Text;
using StringSearching;

namespace findrep
{
    public static class StringReplace
    {
        public static string Replace(IStringSearchAlgorithm algorithm,
            string input,
            string pattern,
            string replace)
        {
            StringBuilder result = new StringBuilder();

            int previousStart = 0;
            foreach (var match in algorithm.Search(pattern, input))
            {
                result.Append(input.Substring(previousStart, match.Start - previousStart));
                result.Append(replace);

                previousStart = match.Start + match.Length;
            }

            result.Append(input.Substring(previousStart));
            return result.ToString();
        }
    }
}
