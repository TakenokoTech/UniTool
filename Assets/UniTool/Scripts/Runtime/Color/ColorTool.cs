using UnityEngine;

namespace UniTool.Scripts.Runtime.Color
{
    public static class ColorTool
    {
        public static UnityEngine.Color? ToColor(this string str)
        {
            if (ColorUtility.TryParseHtmlString(str, out var color)) return color;
            return null;
        }
    }
}