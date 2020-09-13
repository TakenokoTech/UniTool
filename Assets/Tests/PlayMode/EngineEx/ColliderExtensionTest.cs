using System.Collections;
using NUnit.Framework;
using UniTool.EngineEx;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayMode.EngineEx
{
    public class ColliderExtensionTest
    {
        [UnityTest]
        public IEnumerator GetterTest()
        {
            var gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            yield return null;
            var collider2 = gameObject.GetCollider();
            Assert.NotNull(collider2);
        }
    }
}