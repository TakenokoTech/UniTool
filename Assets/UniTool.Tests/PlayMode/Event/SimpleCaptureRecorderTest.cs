#if UNITOOL_ENABLE_RECORDER && UNITY_EDITOR
using System.Collections;
using NUnit.Framework;
using UniTool.EngineEx;
using UniTool.Event;
using UnityEngine;
using UnityEngine.TestTools;

namespace UniTool.Tests.PlayMode.Event
{
    public class SimpleCaptureRecorderTest
    {
        private AudioListener _audioListener;
        
        [OneTimeSetUp]
        public void SetUp()
        {
            _audioListener = new GameObject("AudioListener").AddComponent<AudioListener>();
        }
        
        [OneTimeTearDown]
        public void TearDown()
        {
            _audioListener.gameObject.Destroy();
        }
        
        [UnityTest]
        public IEnumerator RecordingTest()
        {
            var dir = Application.streamingAssetsPath + "/InitTestRecorder";
            SimpleDirectory.DeleteDir(dir);
            SimpleDirectory.CreateDir(dir);
            Assert.AreEqual(1, SimpleDirectory.GetFileName(dir).Count);

            var setting = new CaptureRecorderSetting($"{dir}/record", Screen.width, Screen.height);
            SimpleCaptureRecorder.StartRecording(setting);
            yield return null;
            SimpleCaptureRecorder.StopRecording(setting);

            Assert.AreEqual(3, SimpleDirectory.GetFileName(dir).Count);
        }
    }
}
#endif