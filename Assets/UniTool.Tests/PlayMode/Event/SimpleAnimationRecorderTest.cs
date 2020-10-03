using System.Collections;
using NUnit.Framework;
using UniTool.Event;
using UnityEngine;
using UnityEngine.TestTools;

namespace UniTool.Tests.PlayMode.Event
{
    public class SimpleAnimationRecorderTest
    {
        [UnityTest]
        public IEnumerator AnimationTest()
        {
            var testComponent = GameObject.CreatePrimitive(PrimitiveType.Cube).AddComponent<TestComponent>();
            var clip = new AnimationClip();
            SimpleAnimationRecorder.StartRecording(testComponent, clip);
            yield return new WaitForSeconds(1.0F);
            
            SimpleAnimationRecorder.StopRecording(testComponent);
            Assert.AreEqual(1.0F, clip.length, 0.05F);
            yield return null;
            
            Assert.Null(testComponent.finishedAnimation);
            SimpleAnimationRecorder.PlayOnce(testComponent, clip, testComponent);
            yield return new WaitForSeconds(1.05F);
            
            Assert.NotNull(testComponent.finishedAnimation);
        }

        private class TestComponent : MonoBehaviour, IAnimationListener
        {
            public AnimationClip finishedAnimation = null;
            
            public void OnAnimationFinished(AnimationClip clip)
            {
                finishedAnimation = clip;
            }
        }
    }
}