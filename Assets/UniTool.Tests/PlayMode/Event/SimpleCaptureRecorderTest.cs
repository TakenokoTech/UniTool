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
            LogAssert.ignoreFailingMessages = true;

            var dir = Application.streamingAssetsPath + "/InitTestRecorder";
            SimpleDirectory.DeleteDir(dir);
            SimpleDirectory.CreateDir(dir);
            Assert.AreEqual(1, SimpleDirectory.GetFileName(dir).Count);

            // TODO 録画テスト
            // var setting = new CaptureRecorderSetting( $"{dir}/record", Screen.width, Screen.height);
            var setting = new CaptureRecorderSetting($"{dir}/record", 0, 0);

            SimpleCaptureRecorder.StartRecording(setting);
            yield return null;
            SimpleCaptureRecorder.StopRecording(setting);

            Assert.AreEqual(1, SimpleDirectory.GetFileName(dir).Count);
            LogAssert.ignoreFailingMessages = false;
        }
    }
}
#endif