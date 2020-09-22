using System.Collections;
using NUnit.Framework;
using UniTool.Event;
using UnityEngine;
using UnityEngine.TestTools;

namespace UniTool.Tests.PlayMode.Event
{
    public class SimpleAssetBundleTest
    {
        [UnityTest]
        public IEnumerator PlayTest()
        {
            const string path = "UniTool.Sample/SampleSound";
            var audioClip1 = SimpleAssetBundle.Load<AudioClip>(path, "Sound1");
            yield return null;
            Assert.AreNotEqual(null, audioClip1);
            Assert.AreEqual(1, SimpleAssetBundle.GetRefCount(path));
            
            var audioClip2 = SimpleAssetBundle.Load<AudioClip>(path, "Sound2");
            yield return null;
            Assert.AreNotEqual(null, audioClip2);
            Assert.AreEqual(2, SimpleAssetBundle.GetRefCount(path));
            
            SimpleAssetBundle.Unload(path);
            yield return null;
            Assert.AreNotEqual(null, audioClip1);
            Assert.AreNotEqual(null, audioClip2);
            Assert.AreEqual(1, SimpleAssetBundle.GetRefCount(path));
            
            SimpleAssetBundle.Unload(path);
            yield return null;
            Assert.AreEqual(null, audioClip1);
            Assert.AreEqual(null, audioClip2);
            Assert.AreEqual(1, SimpleAssetBundle.GetRefCount(path));
        }
    }
}