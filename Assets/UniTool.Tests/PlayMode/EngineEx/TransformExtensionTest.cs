using System.Collections;
using NUnit.Framework;
using UniTool.EngineEx;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayMode.EngineEx
{
    public class TransformExtensionTest
    {
        [UnityTest]
        public IEnumerator LookAtCameraTest()
        {
            var gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            gameObject.transform.position = Vector3.zero;
            gameObject.transform.eulerAngles = Vector3.zero;
            yield return null;
            Assert.NotNull(gameObject);
            
            gameObject.transform.LookAtCamera();
            yield return null;
            // Assert.AreEqual(Vector3.zero, gameObject.transform.position);
            // Assert.AreEqual(Vector3.zero, gameObject.transform.eulerAngles);
        }
    }
}