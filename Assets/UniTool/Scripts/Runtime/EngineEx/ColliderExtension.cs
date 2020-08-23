using UnityEngine;

namespace UniTool.Scripts.Runtime.EngineEx
{
    public static class ColliderExtension
    {
        public static Collider GetCollider(this GameObject gameObject) => gameObject.GetComponent<Collider>();
    }
}