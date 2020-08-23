using UnityEngine;

namespace UniTool.Scripts.Runtime.EngineEx
{
    public static class GameObjectExtension
    {
        public static void RemoveComponent<T>(this GameObject gameObject) where T : Component
        {
            var component = gameObject.GetComponent<T>();
            if (component) Object.Destroy(component);
        }

        public static void Destroy(this GameObject gameObject)
        {
            Object.Destroy(gameObject);
        }
    }
}