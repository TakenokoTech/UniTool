using System;
using UnityEngine;

namespace UniTool.Scripts.Runtime.ColorEx
{
    public static class ColorExtension
    {
        public static Color ToColor(this string str)
        {
            if (ColorUtility.TryParseHtmlString(str, out var color)) return color;
            throw new ArgumentException($"{str} cannot be converted to color.");
        }
    }
}