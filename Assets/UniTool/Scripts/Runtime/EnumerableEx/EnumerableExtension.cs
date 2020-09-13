using System.Collections.Generic;
using System.Linq;

namespace UniTool.Scripts.Runtime.EnumerableEx
{
    /// <summary>
    /// System.Collections.Generic.IEnumerable の拡張メソッド
    /// </summary>
    public static class EnumerableExtension
    {
        public static IEnumerable<(int index, T value)> WithIndex<T>(this IEnumerable<T> source) => source.Select((t, i) => (i, t));
    }
}