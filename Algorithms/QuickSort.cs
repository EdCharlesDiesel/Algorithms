using System;

namespace SortingAndSearchingArrayAlgorithms
{
    public class QuickSort<T> : SortingMetrics<T>
        where T : IComparable
    {
        public override T[] MetricSort(T[] items)
        {
            return quicksort(items, 0, items.Length - 1);
        }

        private T[] quicksort(T[] items, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = _pivotRng.Next(left, right);
                int newPivot = partition(items, left, right, pivotIndex);

                quicksort(items, left, newPivot - 1);
                quicksort(items, newPivot + 1, right);
            }

            return items;
        }

        private int partition(T[] items, int left, int right, int pivotIndex)
        {
            T pivotValue = items[pivotIndex];

            Swap(items, pivotIndex, right);

            int storeIndex = left;

            for (int i = left; i < right; i++)
            {
                if (Compare(items[i], pivotValue) < 0)
                {
                    Swap(items, i, storeIndex);
                    storeIndex += 1;
                }
            }

            Swap(items, storeIndex, right);
            return storeIndex;
        }

        Random _pivotRng = new Random();
    }
}
