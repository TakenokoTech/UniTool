using System;
using System.IO;
using System.Reflection;

namespace UniTool.ObjectEx
{
    /// <summary>
    /// 型取得系の拡張メソッド
    /// </summary>
    public static class TypeExtension
    {
        /// <summary>
        /// クラス名を取得する
        /// </summary>
        public static string GetClassName<T>(this T self) => self.GetType().Name;

        /// <summary>
        /// 引数の型を取得する
        /// </summary>
        public static Type GetParametersType(this object self, string methodName, int index) =>
            self.GetMethod(methodName).GetParameters()[index].ParameterType;

        /// <summary>
        /// メソッドを実行する
        /// </summary>
        public static object Invoke(this object self, string methodName, params object[] args) =>
            self.GetMethod(methodName).Invoke(self, args);

        /// <summary>
        /// メソッド情報を取得する
        /// </summary>
        private static MethodInfo GetMethod(this object self, string methodName) =>
            self.GetType().GetMethod(methodName) ?? throw new InvalidDataException();
    }
}