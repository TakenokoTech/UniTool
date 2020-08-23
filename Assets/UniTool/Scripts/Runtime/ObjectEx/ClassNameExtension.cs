namespace UniTool.Scripts.Runtime.ObjectEx
{
    public static class ClassNameExtension
    {
        public static string GetClassName<T>(this T self) => self.GetType().Name;
    }
}