using System;
using System.Collections.Generic;
using System.Linq;
using ads2_heap;
using Xunit;

namespace ads2_heap_tests
{
    public class HeapTests
    {
        [Fact]
        public void RandomAddsPopCorrectly()
        {
            const int count = 10000;

            Heap<int> heap = new Heap<int>();

            Random rnd = new Random();
            foreach(int i in Enumerable.Range(0, count).OrderBy(x => rnd.Next()))
            {
                heap.Push(i);
            }

            for (int i = 0; i < count; i++)
            {
                Assert.Equal(count - i, heap.Count);
                Assert.Equal(i, heap.Top());
                heap.Pop();
                Assert.Equal(count - i - 1, heap.Count);
            }
        }

        [Fact]
        public void OrderedAdds()
        {
            Heap<int> heap = new Heap<int>();

            foreach (int i in Enumerable.Range(0, 10))
            {
                heap.Push(i);
            }

            for (int i = 0; i < 10; i++)
            {
                Assert.Equal(10 - i, heap.Count);
                Assert.Equal(i, heap.Top());
                heap.Pop();
                Assert.Equal(10 - i - 1, heap.Count);
            }
        }

        [Fact]
        public void ReverseOrderedAdds()
        {
            Heap<int> heap = new Heap<int>();

            foreach (int i in Enumerable.Range(0, 10).Reverse())
            {
                heap.Push(i);
            }

            for (int i = 0; i < 10; i++)
            {
                Assert.Equal(10 - i, heap.Count);
                Assert.Equal(i, heap.Top());
                heap.Pop();
                Assert.Equal(10 - i - 1, heap.Count);
            }
        }

        [Fact]
        public void EbbFlow()
        {
            Heap<int> heap = new Heap<int>();

            foreach(int i in Enumerable.Range(0, 10))
            {
                heap.Push(i);
            }

            heap.Pop(); // 0
            heap.Pop(); // 1
            heap.Pop(); // 2
            heap.Pop(); // 3
            heap.Pop(); // 4

            foreach (int i in Enumerable.Range(0, 5))
            {
                heap.Push(i);
            }

            foreach (int i in Enumerable.Range(10, 5))
            {
                heap.Push(i);
            }


            for (int i = 0; i < 15; i++)
            {
                Assert.Equal(15 - i, heap.Count);
                Assert.Equal(i, heap.Top());
                heap.Pop();
                Assert.Equal(15 - i - 1, heap.Count);
            }
        }

        [Fact]
        public void LessThanComparison()
        {
            var lessThan = Comparer<int>.Create(new Comparison<int>((x, y) => x.CompareTo(y)));
            Heap<int> heap = new Heap<int>(lessThan);

            foreach (int i in Enumerable.Range(0, 10))
            {
                heap.Push(i);
            }

            for (int i = 0; i < 10; i++)
            {
                Assert.Equal(10 - i, heap.Count);
                Assert.Equal(i, heap.Top());
                heap.Pop();
                Assert.Equal(10 - i - 1, heap.Count);
            }
        }

        [Fact]
        public void GreaterThanComparison()
        {
            var lessThan = Comparer<int>.Create(new Comparison<int>((x, y) => y.CompareTo(x)));
            Heap<int> heap = new Heap<int>(lessThan);

            foreach (int i in Enumerable.Range(0, 10))
            {
                heap.Push(i);
            }

            for (int i = 0; i < 10; i++)
            {
                Assert.Equal(10 - i, heap.Count);
                Assert.Equal(10 - i - 1, heap.Top());
                heap.Pop();
                Assert.Equal(10 - i - 1, heap.Count);
            }
        }

    }
}
