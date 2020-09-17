using System.Collections.Generic;

namespace UniTool.ObjectEx
{
    /// <summary>
    /// 数値系の拡張メソッド
    /// </summary>
    public static class NumberExtension
    {
        /// <summary>
        /// fromからtoまでの範囲を返します。
        /// </summary>
        public static IEnumerable<int> Until(this int from, int to, int step = 1)
        {
            if (from > to) return new List<int>();

            var list = new List<int>();
            for (var i = from; i < to; i += step) list.Add(i);
            return list;
        }

        /// <summary>
        /// from以上からto以下の範囲を返します。
        /// </summary>
        public static IEnumerable<int> UpTo(this int from, int to, int step = 1)
        {
            if (from > to) return new List<int>();

            var list = new List<int>();
            for (var i = from; i <= to; i += step) list.Add(i);
            return list;
        }

        /// <summary>
        /// from以下からto以上の範囲を返します。
        /// </summary>
        public static IEnumerable<int> DownTo(this int from, int to, int step = 1)
        {
            if (from < to) return new List<int>();

            var list = new List<int>();
            for (var i = from; i >= to; i -= step) list.Add(i);
            return list;
        }
    }
}