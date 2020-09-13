namespace UniTool.ObjectEx
{
    /// <summary>
    /// スコープ関数
    /// </summary>
    public static class ApplyExtension
    {
        public static T Apply<T>(this T obj, ApplyClassBlock<T> block) where T: class
        {
            block(obj);
            return obj;
        }
        
        public static T Apply<T>(this T obj, ApplyStructBlock<T> block) where T: struct
        {
            block(ref obj);
            return obj;
        }
    }
    
    /// <summary>スコープ関数のデリゲート</summary>
    public delegate void ApplyClassBlock<in T>(T self) where T: class;
    
    /// <summary>スコープ関数のデリゲート</summary>
    public delegate void ApplyStructBlock<T>(ref T self) where T: struct;
}