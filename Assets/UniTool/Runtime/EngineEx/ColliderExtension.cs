using UnityEngine;

namespace UniTool.EngineEx
{
    /// <summary>
    /// UnityEngine.Collider の拡張メソッド
    /// </summary>
    public static class ColliderExtension
    {
        /// <summary>GameObject から Collider を取得する</summary>
        public static Collider GetCollider(this GameObject gameObject) => gameObject.GetComponent<Collider>();
    }
}