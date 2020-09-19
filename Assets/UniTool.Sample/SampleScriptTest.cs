using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace UniTool.Sample
{
    public class SampleScriptTest
    {
        [UnityTest]
        public IEnumerator LoadTest()
        {
            var obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            yield return null;
            obj.AddComponent<SampleScript>();
            yield return null;
            Assert.AreEqual(true, obj.activeSelf);
        }
    }
}