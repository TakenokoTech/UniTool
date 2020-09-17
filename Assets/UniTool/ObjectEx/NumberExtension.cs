using System.Collections.Generic;

namespace UniTool.ObjectEx
{
    public static class NumberExtension
    {
        public static IEnumerable<int> Until(this int from, int to, int step = 1)
        {
            if (from > to) return new List<int>();

            var list = new List<int>();
            for (var i = from; i < to; i += step) list.Add(i);
            return list;
        }

        public static IEnumerable<int> UpTo(this int from, int to, int step = 1)
        {
            if (from > to) return new List<int>();

            var list = new List<int>();
            for (var i = from; i <= to; i += step) list.Add(i);
            return list;
        }

        public static IEnumerable<int> DownTo(this int from, int to, int step = 1)
        {
            if (from < to) return new List<int>();

            var list = new List<int>();
            for (var i = from; i >= to; i -= step) list.Add(i);
            return list;
        }
    }
}