using UnityEngine;

namespace UniTool.EngineEx
{
    /// <summary>
    /// UnityEngine.Transform の拡張メソッド
    /// </summary>
    public static class TransformExtension
    {
        /// <summary>カメラに向ける</summary>
        public static void LookAtCamera(this Transform transform)
        {
            if (Camera.main != null) transform.LookAt(Camera.main.transform);
        }
    }
}