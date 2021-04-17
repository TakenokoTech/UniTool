#if UNITOOL_ENABLE_RECORDER
using UniTool.Event;
using UniTool.Logger;
using UnityEngine;

namespace UniTool.Sample
{
    public class UnitoolSampleScript2 : MonoBehaviour
    {
        private readonly CaptureRecorderSetting _recorderSetting = new CaptureRecorderSetting("Build/sample");

        private void OnEnable()
        {
            // SimpleCaptureRecorder.StartRecording(_recorderSetting);
            SimpleSnapshot.Take(new SnapshotSetting(Camera.current));
            FileLogger.Start();
        }

        private void OnDisable()
        {
            SimpleCaptureRecorder.StopRecording(_recorderSetting);
            FileLogger.Stop();
        }
    }
}
#endif
