using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UniTool.Scripts.Runtime.EngineEx;
using UnityEngine;
using UnityEngine.TestTools;

namespace UniTool.Tests.PlayMode.EngineEx
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