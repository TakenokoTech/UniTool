#if UNITOOL_ENABLE_RECORDER
using System.Collections;
using NUnit.Framework;
using UniTool.Event;
using UnityEngine;
using UnityEngine.TestTools;

namespace UniTool.Tests.PlayMode.Event
{
    public class SimpleCaptureRecorderTest
    {
        [UnityTest]
        public IEnumerator RecordingTest()
        {
            var dir = Application.streamingAssetsPath + "/InitTestRecorder";
            SimpleDirectory.DeleteDir(dir);
            SimpleDirectory.CreateDir(dir);
            Assert.AreEqual(1, SimpleDirectory.GetFileName(dir).Count);

            var setting = new CaptureRecorderSetting($"{dir}/record", 480, 320);
            SimpleCaptureRecorder.StartRecording(setting);
            yield return new WaitForSeconds(1F);
            SimpleCaptureRecorder.StopRecording(setting);
            
            Assert.AreEqual(2, SimpleDirectory.GetFileName(dir).Count);
        }
    }
}
#endif