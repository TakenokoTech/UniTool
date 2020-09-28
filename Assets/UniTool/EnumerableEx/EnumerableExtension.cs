using System;
using System.Collections.Generic;
using System.Linq;

namespace UniTool.EnumerableEx
{
    /// <summary>
    /// System.Collections.Generic.IEnumerable の拡張メソッド
    /// </summary>
    public static class EnumerableExtension
    {
        public static IEnumerable<(int index, T value)> WithIndex<T>(this IEnumerable<T> source) =>
            source.Select((t, i) => (i, t));

        public static void Foreach<T>(this IEnumerable<T> source, Action<T> block)
        {
            foreach (var t in source) block(t);
        }
    }
}