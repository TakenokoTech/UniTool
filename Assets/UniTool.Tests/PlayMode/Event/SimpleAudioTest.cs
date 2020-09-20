using System.Collections;
using NUnit.Framework;
using UniTool.EngineEx;
using UniTool.Event;
using UnityEngine;
using UnityEngine.TestTools;

namespace UniTool.Tests.PlayMode.Event
{
    public class SimpleAudioTest
    {
        private AudioListener _audioListener;
        private readonly AudioClip _audioClip = AudioClip.Create("testSound", 44100 * 2, 1, 44100, true);

        [SetUp]
        public void SetUp()
        {
            _audioListener = new GameObject("AudioListener").AddComponent<AudioListener>();
        }
        
        [TearDown]
        public void TearDown()
        {
            _audioListener.gameObject.Destroy();
        }
        
        [UnityTest]
        public IEnumerator PlayTest()
        {
            const string tag = "test1";
            SimpleAudio.Play(_audioClip, tag);
            yield return null;

            var soundName = SimpleAudio.GetSoundName(tag);
            var audio = GameObject.Find(soundName).GetComponent<AudioSource>();

            Assert.AreEqual(Vector3.zero, audio.transform.position);
            Assert.AreEqual(true, audio.isPlaying);

            while (GameObject.Find(soundName) != null) yield return new WaitForSeconds(0.1F);
            Assert.AreEqual(null, GameObject.Find(soundName));
        }

        [UnityTest]
        public IEnumerator Play3DTest()
        {
            const string tag = "test2";
            SimpleAudio.Play3D(_audioClip, Vector3.one, tag);
            yield return null;

            var soundName = SimpleAudio.GetSoundName(tag);
            var audio = GameObject.Find(soundName).GetComponent<AudioSource>();

            Assert.AreEqual(Vector3.one, audio.transform.position);
            Assert.AreEqual(true, audio.isPlaying);

            while (GameObject.Find(soundName) != null) yield return new WaitForSeconds(0.1F);
            Assert.AreEqual(null, GameObject.Find(soundName));
        }
    }
}