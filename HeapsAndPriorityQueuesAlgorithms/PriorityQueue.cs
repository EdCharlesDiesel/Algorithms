using System.Collections.Generic;

namespace ads2_heap
{
    public class PriorityQueue<T>
    {
        readonly Heap<T> heap;

        public PriorityQueue()
            : this(Comparer<T>.Default)
        {
        }

        public PriorityQueue(IComparer<T> comparer)
        {
            heap = new Heap<T>(comparer);
        }

        public void Enqueue(T value)
        {
            heap.Push(value);
        }

        public T Deque()
        {
            T value = heap.Top();
            heap.Pop();

            return value;
        }

        public int Count
        {
            get
            {
                return heap.Count;
            }
        }
    }
}
