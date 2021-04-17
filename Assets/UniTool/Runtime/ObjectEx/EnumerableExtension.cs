using System;
using System.Collections.Generic;
using System.Linq;

namespace UniTool.ObjectEx
{
    /// <summary>
    /// System.Collections.Generic.IEnumerable の拡張メソッド
    /// </summary>
    public static class EnumerableExtension
    {
        public static IEnumerable<(int index, T value)> WithIndex<T>(this IEnumerable<T> source)
        {
            return source.Select((t, i) => (i, t));
        }

        public static void Foreach<T>(this IEnumerable<T> source, Action<T> block)
        {
            foreach (var t in source) block(t);
        }
        
        public static void ForeachIndexed<T>(this IEnumerable<T> source, Action<int, T> block)
        {
            foreach (var (index, t) in source.WithIndex()) block(index, t);
        }

        public static IEnumerable<T2> Map<T1, T2>(this IEnumerable<T1> source, Func<T1, T2> block)
        {
            return source.Select(block);
        }
        
        public static IEnumerable<T2> MapIndexed<T1, T2>(this IEnumerable<T1> source, Func<int, T1, T2> block)
        {
            return source.Select((t, index)  => block(index, t));
        }
        
        public static IEnumerable<T> FilterNotNull<T>(this IEnumerable<T> source)
        {
            return source.Where(t => t != null);
        }
    }
}