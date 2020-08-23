using UnityEngine;

namespace UniTool.Scripts.Runtime.EngineEx
{
    public static class TransformExtension
    {
        public static void LookAtCamera(this Transform transform)
        {
            if (Camera.main != null) transform.LookAt(Camera.main.transform);
        }
    }
}