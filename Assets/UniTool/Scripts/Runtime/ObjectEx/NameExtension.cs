namespace UniTool.Scripts.Runtime.ObjectEx
{
    /// <summary>
    /// 名前取得系の拡張メソッド
    /// </summary>
    public static class NameExtension
    {
        /// <summary>
        /// クラス名を取得する
        /// </summary>
        public static string GetClassName<T>(this T self) => self.GetType().Name;
    }
}