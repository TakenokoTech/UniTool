using System;
using UnityEngine;

namespace UniTool.ColorEx
{
    /// <summary>
    /// UnityEngine.Color の拡張メソッド
    /// </summary>
    public static class ColorExtension
    {
        /// <summary>String から UnityEngine.Color に変換する</summary>
        /// <param name="str">16進数カラーコード</param>
        /// <example>"#123456".ToColor()</example>
        public static Color ToColor(this string str)
        {
            if (ColorUtility.TryParseHtmlString(str, out var color)) return color;
            throw new ArgumentException($"{str} cannot be converted to color.");
        }
    }
}