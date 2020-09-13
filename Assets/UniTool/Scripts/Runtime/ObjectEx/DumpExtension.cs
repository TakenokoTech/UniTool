using System.Linq;
using System.Reflection;

namespace UniTool.Scripts.Runtime.ObjectEx
{
    /// <summary>
    /// デバッグ系の拡張メソッド
    /// </summary>
    public static class DebugExtension
    {
        /// <summary>クラス内のフィールド、プロパティを表示する</summary>
        public static string Dump<T>(this T obj)
        {
            const string separator = ",";
            const string format = "{0}={1}";
             
            var fields = string.Join(separator, obj
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.Public)
                .Select(c => string.Format(format, c.Name, c.GetValue(obj))));
             
            var properties = string.Join(separator, obj
                .GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(c => c.CanRead)
                .Select(c => string.Format(format, c.Name, c.GetValue(obj))));

            if ("".Equals(properties) && "".Equals(fields))
            {
                return "{}";
            }
            else if ("".Equals(fields))
            {
                return "{" + properties + "}";
            }
            else if ("".Equals(properties))
            {
                return "{" + fields + "}";
            }
            else
            {
                return "{" + string.Join(separator, fields, properties) + "}";
            }
        }
    }
}