using System.Collections;
using NUnit.Framework;
using UniTool.Scripts.Runtime.EngineEx;
using UnityEngine;
using UnityEngine.TestTools;

namespace UniTool.Tests.PlayMode.EngineEx
{
    public class GameObjectExtensionTest
    {
        [UnityTest]
        public IEnumerator RemoveComponentTest()
        {
            var gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            yield return null;
            var rigidBody1 = gameObject.GetComponent<Rigidbody>();
            Assert.Null(rigidBody1);
            
            gameObject.AddComponent<Rigidbody>();
            yield return null;
            var rigidBody2 = gameObject.GetComponent<Rigidbody>();
            Assert.NotNull(rigidBody2);
            
            gameObject.RemoveComponent<Rigidbody>();
            yield return null;
            var rigidBody3 = gameObject.GetComponent<Rigidbody>();
            Assert.Null(rigidBody3);
        }
        
        [UnityTest]
        public IEnumerator DestroyTest()
        {
            var gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            yield return null;
            Assert.NotNull(gameObject);
           
            gameObject.Destroy();
            yield return null;
            Assert.True(gameObject == null);
        }
    }
}