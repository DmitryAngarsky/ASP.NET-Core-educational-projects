using System;
using System.Collections.Generic;

namespace UnitTestApp.Test
{
    public class Comparer
    {
        public static Comparer<U> Get<U>(Func<U, U, bool> func)
        {
            return new Comparer<U>(func);
        }
    }

    public class Comparer<T>: Comparer, IEqualityComparer<T>
    {
        private Func<T, T, bool> comparissonFunction;

        public Comparer(Func<T, T, bool> func)
        {
            comparissonFunction = func;
        }

        public bool Equals(T x, T y)
        {
            return comparissonFunction(x, y);
        }

        public int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }
    }
}
