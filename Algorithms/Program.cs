using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace SortingAndSearchingArrayAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int iterations = 20000;

            if(args.Length > 0
                && !int.TryParse(args[0], out iterations)
                && iterations <= 0)
            {
                Console.WriteLine("Error: iteration count must be a positive integer.");
            }
            else
            {
                RunTests(iterations);
            }
        }

        static void RunTests(int iterations)
        {
            Dictionary<string, SortingMetrics<int>> algorithms = new Dictionary<string, SortingMetrics<int>>
            {
                { "Bubble Sort", new BubbleSort<int>() },
                { "Insertion Sort", new InsertionSort<int>() },
                { "Merge Sort", new MergeSort<int>() },
                { "Quick Sort", new QuickSort<int>() }
            };

            int[] testdata = RandomArray(iterations);

            foreach(var kvp in algorithms)
            {
                Console.WriteLine("Executing: {0}", kvp.Key);

                Stopwatch timer = Stopwatch.StartNew();
                kvp.Value.Sort(CopyArray(testdata));
                timer.Stop();

                Console.WriteLine("       Length: {0}", testdata.Length);
                Console.WriteLine("  Comparisons: {0}", kvp.Value.Comparisons);
                Console.WriteLine("        Swaps: {0}", kvp.Value.Swaps);
                Console.WriteLine("      Seconds: {0}", timer.Elapsed.TotalSeconds);
                Console.WriteLine("------------------");
            }
        }

        private static Random _rng = new Random();

        private static int[] RandomArray(int length)
        {
            int[] data = new int[length];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = _rng.Next();
            }

            return data;
        }

        private static int[] CopyArray(int[] origional)
        {
            int[] copy = new int[origional.Length];
            for(int i = 0; i < origional.Length; i++)
            {
                copy[i] = origional[i];
            }

            return copy;
        }
    }
}
