using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UniTool.EngineEx;

namespace UniTool.Tests.PlayMode.EngineEx
{
    public class AudioSourceExtensionTest
    {
        private const int SampleRate = 44100;
        private readonly AudioClip _audioClip = AudioClip.Create("testSound", SampleRate * 2, 1, SampleRate, true);

        [UnityTest]
        public IEnumerator AudioTest()
        {
            var gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            yield return null;
            
            var audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.SetClip(_audioClip).SetOutput(null).Mute();
            yield return null;
            
            Assert.AreEqual(_audioClip, audioSource.clip);
            Assert.AreEqual(1F, audioSource.volume);
            Assert.AreEqual(1F, audioSource.pitch);
            Assert.AreEqual(true, audioSource.mute);
                
            audioSource.SetVolume(0.5F).SetPitch(0.5F).Unmute();
            yield return null;
            
            Assert.AreEqual(0.5F, audioSource.volume);
            Assert.AreEqual(0.5F, audioSource.pitch);
            Assert.AreEqual(false, audioSource.mute);
        }
    }
}