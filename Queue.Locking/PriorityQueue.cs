using System.Collections.Generic;
using Queue.Common;

namespace Queue.Locking
{
    public class PriorityQueue<T> : IQueue<T>
    {
        readonly Heap<T> heap;
        readonly object syncLock = new object();

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
            lock (syncLock)
            {
                heap.Push(value);
            }
        }

        public T Dequeue()
        {
            lock (syncLock)
            {
                if (heap.Empty)
                {
                    throw new QueueEmptyException();
                }

                T value = heap.Top();
                heap.Pop();

                return value;
            }
        }

        public T Peek()
        {
            lock (syncLock)
            {
                if (heap.Empty)
                {
                    throw new QueueEmptyException();
                }

                return heap.Top();
            }
        }

        public void Clear()
        {
            lock (syncLock)
            {
                heap.Clear();
            }
        }

        public int Count
        {
            get
            {
                lock (syncLock)
                {
                    return heap.Count;
                }
            }
        }
    }
}
