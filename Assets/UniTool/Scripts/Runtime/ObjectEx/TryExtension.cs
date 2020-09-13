using System;

namespace UniTool.Scripts.Runtime.ObjectEx
{
    /// <summary>
    /// Try系の拡張メソッド
    /// </summary>
    public static class TryExtension
    {
        /// <summary>
        /// エラーハンドリングを行い、<c>Promise&lt;T&gt;</c>を返却する。
        /// </summary>
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

    /// <summary>エラーハンドリング用のデリゲート</summary>
    public delegate TR TryBlock<in T, out TR>(T self);
}