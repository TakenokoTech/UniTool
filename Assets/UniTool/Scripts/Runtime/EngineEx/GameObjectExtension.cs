using UnityEngine;

namespace UniTool.Scripts.Runtime.EngineEx
{
    public static class GameObjectExtension
    {
        public static GameObject RemoveComponent<T>(this GameObject gameObject) where T : Component
        {
            var component = gameObject.GetComponent<T>();
            if (component) Object.Destroy(component);
            return gameObject;
        }
        
        public static GameObject Destroy(this GameObject gameObject)
        {
            Object.Destroy(gameObject);
            return gameObject;
        }

        public static GameObject LookAt(this GameObject gameObject)
        {
            return gameObject;
        }
    }
}