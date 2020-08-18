using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Animations;

namespace UniTool.Scripts.Runtime.Engine
{
    public static class GameObjectExtension
    {
        public static UnityEngine.GameObject RemoveComponent<T>(this UnityEngine.GameObject gameObject) where T : Component
        {
            var component = gameObject.GetComponent<T>();
            if (component) Object.Destroy(component);
            return gameObject;
        }
        
        public static UnityEngine.GameObject Destroy(this UnityEngine.GameObject gameObject)
        {
            Object.Destroy(gameObject);
            return gameObject;
        }

        public static UnityEngine.GameObject LookAt(this UnityEngine.GameObject gameObject)
        {
            return gameObject;
        }
    }
}