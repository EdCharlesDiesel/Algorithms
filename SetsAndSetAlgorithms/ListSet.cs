using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Set.List
{
    public class Set<T> : ISet<T>
        where T : IComparable<T>
    {
        private readonly LinkedList<T> _store;

        public Set()
        {
            _store = new LinkedList<T>();
        }

        public Set(IEnumerable<T> values)
            : this()
        {
            AddRange(values);
        }

        public bool Add(T value)
        {
            if (!_store.Contains(value))
            {
                _store.Add(value);
                return true;
            }

            return false;
        }

        private void AddRange(IEnumerable<T> values)
        {
            foreach (T value in values)
            {
                Add(value);
            }
        }

        public bool Contains(T value)
        {
            return _store.Contains(value);
        }

        public bool Remove(T value)
        {
            return _store.Remove(value);
        }

        public int Count
        {
            get
            {
                return _store.Count;
            }
        }


        // Set algebra operations
        public ISet<T> Union(ISet<T> other)
        {
            Set<T> result = new Set<T>(other);
            result.AddRange(_store);

            return result;
        }

        public ISet<T> Intersection(ISet<T> other)
        {
            ISet<T> result = new Set<T>();
            foreach (T item in other)
            {
                if (Contains(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public ISet<T> Difference(ISet<T> other)
        {
            ISet<T> result = new Set<T>(_store);

            foreach (T item in other)
            {
                result.Remove(item);
            }

            return result;
        }

        public ISet<T> SymmetricDifference(ISet<T> other)
        {
            ISet<T> intersection = Intersection(other);
            ISet<T> union = Union(other);

            return union.Difference(intersection);
        }

        // IEnumerable<T> operations
        public IEnumerator<T> GetEnumerator()
        {
            return _store.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _store.GetEnumerator();
        }
    }
}