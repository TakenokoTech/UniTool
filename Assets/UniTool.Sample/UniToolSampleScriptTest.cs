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
            obj.AddComponent<UnitoolSampleScript1>();
            yield return null;
            Assert.AreEqual(true, obj.activeSelf);
            
            obj.SetActive(false);
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator LoadTest2()
        {
            var obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            yield return null;
            obj.AddComponent<UnitoolSampleScript2>();
            yield return null;
            Assert.AreEqual(true, obj.activeSelf);
            
            obj.SetActive(false);
            yield return null;
        }
    }
}