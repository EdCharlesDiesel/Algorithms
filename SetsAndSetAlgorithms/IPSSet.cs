using System;
using System.Collections.Generic;

namespace DataStructures
{
    public interface ISet<T> : IEnumerable<T>
        where T: IComparable<T>
    {
        bool Add(T value);
        bool Remove(T value);
        bool Contains(T value);

        int Count { get; }

        ISet<T> Union(ISet<T> other);
        ISet<T> Intersection(ISet<T> other);
        ISet<T> Difference(ISet<T> other);
        ISet<T> SymmetricDifference(ISet<T> other);
    }
}
