using System.Collections.Generic;
using Queue.Common;

namespace Queue.NonLocking
{
    public class PriorityQueue<T> : IQueue<T>
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

        public T Dequeue()
        {
            if (heap.Empty)
            {
                throw new QueueEmptyException();
            }

            T value = heap.Top();
            heap.Pop();

            return value;
        }

        public T Peek()
        {
            if (heap.Empty)
            {
                throw new QueueEmptyException();
            }

            return heap.Top();
        }

        public void Clear()
        {
            heap.Clear();
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
