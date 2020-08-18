using System;

namespace UniTool.Scripts.Runtime.Extension.Object
{
    public static class ApplyExtension
    {
        public static T Apply<T>(this T obj, Action<T> block)
        {
            block(obj);
            return obj;
        }
    }
}