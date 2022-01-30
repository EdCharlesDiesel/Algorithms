using System;
using System.Collections.Generic;

namespace Queue.Common
{
    public class Heap<T>
    {
        const uint DEFAULT_CAPACITY = 7;
        readonly IComparer<T> comparer;
        uint capacity = 0;
        T[] data = null;

        public int Count { get; private set; }

        public Heap() : this(Comparer<T>.Default)
        { }

        public Heap(IComparer<T> comparer)
        {
            this.comparer = comparer;
            Reset(DEFAULT_CAPACITY);
        }

        private bool Compare(int left, int right)
        {
            return comparer.Compare(data[left], data[right]) < 0;
        }

        public void Pop()
        {
            if (Count <= 1)
            {
                Count = 0;
                return;
            }

            data[0] = data[Count - 1];
            Count--;

            PushDownIfNeeded(0);
        }

        private void PushDownIfNeeded(int parent)
        {
            int lchild = Left(parent);
            int rchild = Right(parent);

            //scenario 1: no child
            if (lchild >= Count)
            {
                return;
            }

            // scenario 2: only-left
            if (rchild >= Count)
            {
                // the parent is less than it's left child
                if (Compare(lchild, parent))
                {
                    Swap(parent, lchild);
                    PushDownIfNeeded(lchild);
                    return;
                }
            }

            // scenario 3: two children
            if (Compare(lchild, rchild))
            {
                if (Compare(lchild, parent))
                {
                    Swap(parent, lchild);
                    PushDownIfNeeded(lchild);
                    return;
                }
            }
            else
                if (Compare(rchild, parent))
            {
                Swap(parent, rchild);
                PushDownIfNeeded(rchild);
                return;
            }
        }

        public T Top()
        {
            if (Count > 0)
            {
                return data[0];
            }

            throw new Exception("Top called on empty heap");
        }

        public void Push(T value)
        {
            GrowIfNeeded();

            data[Count] = value;

            int index = Count;

            while (index > 0 && Compare(index, Parent(index)))
            {
                Swap(Parent(index), index);
                index = Parent(index);
            }

            Count++;
        }

        private void GrowIfNeeded()
        {
            if (Count == capacity)
            {
                capacity = capacity * 2 + 1;
                T[] larger = new T[capacity];

                for (int i = 0; i < Count; i++)
                {
                    larger[i] = data[i];
                }

                data = larger;
            }
        }

        private void Swap(int left, int right)
        {
            T temp = data[left];
            data[left] = data[right];
            data[right] = temp;
        }

        private int Parent(int index)
        {
            return (index - 1) / 2;
        }

        private int Left(int index)
        {
            return 2 * index + 1;
        }

        private int Right(int index)
        {
            return 2 * index + 2;
        }

        public bool Empty
        {
            get
            {
                return Count == 0;
            }
        }

        private void Reset(uint capacity)
        {
            this.capacity = capacity;
            data = new T[this.capacity];
            Count = 0;
        }

        public void Clear()
        {
            Reset(DEFAULT_CAPACITY);
        }
    }
}
