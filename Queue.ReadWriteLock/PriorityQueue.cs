using System.Collections.Generic;
using System.Threading;
using Queue.Common;

namespace Queue.ReadWriteLock
{
    public class PriorityQueue<T> : IQueue<T>
    {
        readonly Heap<T> heap;
        readonly ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();

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
            rwLock.EnterWriteLock();
            try
            {
                heap.Push(value);
            }
            finally
            {
                rwLock.ExitWriteLock();
            }
        }

        public T Dequeue()
        {
            rwLock.EnterWriteLock();
            try
            {
                if (heap.Empty)
                {
                    throw new QueueEmptyException();
                }

                T value = heap.Top();
                heap.Pop();

                return value;
            }
            finally
            {
                rwLock.ExitWriteLock();
            }
        }

        public T Peek()
        {
            rwLock.EnterReadLock();
            try
            {
                if (heap.Empty)
                {
                    throw new QueueEmptyException();
                }

                return heap.Top();
            }
            finally
            {
                rwLock.ExitReadLock();
            }

        }

        public void Clear()
        {
            rwLock.EnterWriteLock();
            try
            {
                heap.Clear();
            }
            finally
            {
                rwLock.ExitWriteLock();
            }
        }

        public int Count
        {
            get
            {
                rwLock.EnterReadLock();
                try
                {
                    return heap.Count;
                }
                finally
                {
                    rwLock.ExitReadLock();
                }
            }
        }
    }
}
