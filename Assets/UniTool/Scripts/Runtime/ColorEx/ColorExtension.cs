using System;
using UnityEngine;

namespace UniTool.Scripts.Runtime.ColorEx
{
    /// <summary>
    /// UnityEngine.Color の拡張メソッド
    /// </summary>
    public static class ColorExtension
    {
        
        /// <summary>
        /// String から UnityEngine.Color に変換する
        /// </summary>
        public static Color ToColor(this string str)
        {
            if (ColorUtility.TryParseHtmlString(str, out var color)) return color;
            throw new ArgumentException($"{str} cannot be converted to color.");
        }
    }
}