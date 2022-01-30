using System;
namespace SortingAndSearchingArrayAlgorithms
{
    public abstract class SortingMetrics<T> : ISorting<T>
        where T: IComparable
    {
        public long Swaps { get; private set; }
        public long Comparisons { get; private set; }

        public T[] Sort(T[] data)
        {
            Reset();
            return MetricSort(data);
        }

        public abstract T[] MetricSort(T[] data);

        protected void Reset()
        {
            Swaps = 0;
            Comparisons = 0;
        }

        protected void Swap(T[] data, int left, int right)
        {
            T temp = data[left];
            data[left] = data[right];
            data[right] = temp;

            Swaps++;
        }

        protected void Assign(T[] data, int index, T value)
        {
            data[index] = value;
            Swaps++;
        }

        protected int Compare(T left, T right)
        {
            Comparisons++;
            return left.CompareTo(right);
        }

        protected int Compare(T[] data, int left, int right)
        {
            return Compare(data[left], data[right]);
        }

        protected bool LessThan(T[] data, int left, int right)
        {
            return Compare(data, left, right) < 0;
        }

        protected bool GreaterThan(T[] data, int left, int right)
        {
            return Compare(data, left, right) > 0;
        }

        protected bool EqualTo(T[] data, int left, int right)
        {
            return Compare(data, left, right) == 0;
        }
    }
}
