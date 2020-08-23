using System;

namespace UniTool.Scripts.Runtime.ObjectEx
{
    public static class TryExtension
    {
        public static Promise<TR> RunCatching<T, TR>(this T self, TryBlock<T, TR> block)
        {
            try
            {
                return new Promise<TR>(block(self));
            }
            catch (Exception e)
            {
                return new Promise<TR>(e);
            }
        }
    }

    public delegate TR TryBlock<in T, out TR>(T self);
}