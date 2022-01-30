using System;
namespace SortingAndSearchingArrayAlgorithms
{
    public class InsertionSort<T> : SortingMetrics<T>
        where T: IComparable
    {
        public override T[] MetricSort(T[] data)
        {
            for(int i = 1; i < data.Length; i++)
            {
                if(LessThan(data, i, i-1))
                {
                    for(int p = i; p > 0; p--)
                    {
                        if(LessThan(data, p, p-1))
                        {
                            Swap(data, p, p - 1);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            return data;
        }
    }
}
