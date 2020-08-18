using System;
using System.Collections.Generic;

namespace UniTool.Scripts.Runtime.Extension.Enumerable
{
    public static class WithIndexEnumerableExtension
    {
        public static IEnumerable<(int index, T value)> WithIndex<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            
            IEnumerable<(int index, T value)> Impl()
            {
                var i = 0;
                foreach (var value in source) yield return (i++, value);
            }
            
            return Impl();
        }
    }
}