using System;

namespace UniTool.ObjectEx
{
    /// <summary>
    /// 非同期処理の結果
    /// </summary>
    public class Promise<T>
    {
        /// <summary>成功時の値</summary>
        public readonly T Value;

        /// <summary>失敗時の値</summary>
        public readonly Exception Err = null;

        /// <summary>成功したか</summary>
        public readonly bool IsSuccess = false;

        public Promise(T value)
        {
            IsSuccess = true;
            Value = value;
            Err = null;
        }

        public Promise(Exception e)
        {
            IsSuccess = false;
            Err = e;
        }

        /// <summary>結果の取得または、デフォルト値を返却する</summary>
        /// <param name="def">デフォルト値</param>
        public T GetOrDefault(T def)
        {
            return IsSuccess ? Value : def;
        }
    }
}