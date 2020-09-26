using System;
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
        public IEnumerator SoundTest()
        {
            var outputPathSound = Application.streamingAssetsPath + "/AssetBundleTest/sound";
            Assert.AreEqual(2, SimpleAssetBundle.GetAllAssetNames(outputPathSound).Length);
            Assert.AreEqual(0, SimpleAssetBundle.GetAllScenePaths(outputPathSound).Length);
            
            Debug.Log(string.Join(Environment.NewLine, SimpleAssetBundle.GetAllAssetNames(outputPathSound)));
            
            var audioClip1 = SimpleAssetBundle.Load<AudioClip>(outputPathSound, SimpleAssetBundle.GetAllAssetNames(outputPathSound)[0]);
            yield return null;
            Assert.AreEqual(1, SimpleAssetBundle.GetRefCount(outputPathSound));
            Assert.AreNotEqual(null, audioClip1);

            var audioClip2 = SimpleAssetBundle.Load<AudioClip>(outputPathSound, SimpleAssetBundle.GetAllAssetNames(outputPathSound)[1]);
            yield return null;
            Assert.AreEqual(2, SimpleAssetBundle.GetRefCount(outputPathSound));
            Assert.AreNotEqual(null, audioClip2);
            
            SimpleAssetBundle.Unload(outputPathSound);
            yield return null;
            Assert.AreEqual(1, SimpleAssetBundle.GetRefCount(outputPathSound));
            Assert.AreNotEqual(null, audioClip1);
            Assert.AreNotEqual(null, audioClip2);

            SimpleAssetBundle.Unload(outputPathSound);
            yield return null;
            Assert.AreEqual(null, SimpleAssetBundle.GetRefCount(outputPathSound));

            SimpleAssetBundle.Unload(outputPathSound);
            yield return null;
            Assert.AreEqual(null, SimpleAssetBundle.GetRefCount(outputPathSound));
        }

        [UnityTest]
        public IEnumerator SceneTest()
        {
            var outputPathScene = Application.streamingAssetsPath + "/AssetBundleTest/scene";
            Assert.AreEqual(0, SimpleAssetBundle.GetAllAssetNames(outputPathScene).Length);
            Assert.AreEqual(3, SimpleAssetBundle.GetAllScenePaths(outputPathScene).Length);
            yield return null;
        }
    }
}