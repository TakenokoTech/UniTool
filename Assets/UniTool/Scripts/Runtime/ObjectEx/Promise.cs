using System;

namespace UniTool.Scripts.Runtime.ObjectEx
{
    /**
    public class Promise<T> where T : struct
    {
        public T? Value;
        public Exception Err = null;
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
            Value = null;
            Err = e;
        }
        public T? GetOrNull() => IsSuccess ? Value : null;
        public T? GetOrDefault(T? def) => IsSuccess ? Value : def;
    }
    **/
    
    /// <summary>
    /// 非同期処理の最終的な完了処理もしくは失敗、およびその結果の値
    /// </summary>
    public class Promise<T>
    {
        public readonly T Value;
        public readonly Exception Err = null;
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

        public T GetOrDefault(T def)
        {
            return IsSuccess ? Value : def;
        }
    }
}