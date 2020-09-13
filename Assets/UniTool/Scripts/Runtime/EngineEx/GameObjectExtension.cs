using UnityEngine;

namespace UniTool.Scripts.Runtime.EngineEx
{
    /// <summary>
    /// UnityEngine.GameObject の拡張メソッド
    /// </summary>
    public static class GameObjectExtension
    {
        /// <summary>コンポーネントを消去する</summary>
        public static void RemoveComponent<T>(this GameObject gameObject) where T : Component
        {
            var component = gameObject.GetComponent<T>();
            if (component) Object.Destroy(component);
        }

        /// <summary>自身を消去する</summary>
        public static void Destroy(this GameObject gameObject)
        {
            Object.Destroy(gameObject);
        }
    }
}