using System.Collections;
using NUnit.Framework;
using UniTool.EngineEx;
using UnityEngine;
using UnityEngine.TestTools;

namespace UniTool.Tests.PlayMode.EngineEx
{
    public class AnimationExtensionTest
    {
        [UnityTest]
        public IEnumerator AnimationTest()
        {
            var gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            var animation = gameObject.AddComponent<Animation>();
            yield return null;
            
            Assert.AreEqual(animation, gameObject.GetAnimation());
        }
        
        [UnityTest]
        public IEnumerator AnimationClipTest()
        {
            var clip = new AnimationClip();
            Assert.AreEqual(false, clip.legacy);
            Assert.AreEqual(WrapMode.Default, clip.wrapMode);
            
            clip.EnableLegacy();
            yield return null;
            Assert.AreEqual(true, clip.legacy);
            
            clip.DisableLegacy();
            yield return null;
            Assert.AreEqual(false, clip.legacy);

            clip.WrapModeClampForever();
            yield return null;
            Assert.AreEqual(WrapMode.ClampForever, clip.wrapMode);
            
            clip.WrapModeLoop();
            yield return null;
            Assert.AreEqual(WrapMode.Loop, clip.wrapMode);
        }
    }
}