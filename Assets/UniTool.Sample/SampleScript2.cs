using UniTool.Event;
using UnityEngine;

namespace UniTool.Sample
{
    public class SampleScript2 : MonoBehaviour
    {
#if UNITOOL_ENABLE_RECORDER
        private readonly CaptureRecorderSetting _recorderSetting = new CaptureRecorderSetting("Build");

        private void OnEnable()
        {
            SimpleCaptureRecorder.StartRecording(_recorderSetting);
            // SimpleSnapshot.Take(new SnapshotSetting(Camera.main));
        }

        private void OnDisable()
        {
            SimpleCaptureRecorder.StopRecording(_recorderSetting);
        }
#endif
    }
}