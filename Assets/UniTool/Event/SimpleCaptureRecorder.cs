#if UNITOOL_ENABLE_RECORDER && UNITY_EDITOR
using System.Collections.Generic;
using UniTool.ObjectEx;
using UnityEditor.Recorder;
using UnityEditor.Recorder.Input;
using UnityEngine;

namespace UniTool.Event
{
    /// <summary>
    /// 簡易動画撮影
    /// </summary>
    public class SimpleCaptureRecorder
    {
        private static readonly SimpleCaptureRecorder Instance = new SimpleCaptureRecorder();
        private readonly Dictionary<string, RecorderController> _dic = new Dictionary<string, RecorderController>();

        /// <summary>
        /// 記録開始
        /// </summary>
        public static void StartRecording(CaptureRecorderSetting setting)
        {
            if (!Application.isPlaying) return;
            RecorderOptions.VerboseMode = true;

            var outputFile = setting.FilePath;
            var movieRecorderSettings = ScriptableObject.CreateInstance<MovieRecorderSettings>().Apply(self =>
            {
                self.ImageInputSettings = new GameViewInputSettings {OutputWidth = setting.Width, OutputHeight = setting.Height};
                self.AudioInputSettings.PreserveAudio = true;
                self.OutputFile = outputFile;
                self.OutputFormat = MovieRecorderSettings.VideoRecorderOutputFormat.MP4;
                self.Enabled = true;
            });
            var recorderControllerSettings = ScriptableObject.CreateInstance<RecorderControllerSettings>().Apply(self =>
            {
                self.FrameRate = 30.0f;
                self.AddRecorderSettings(movieRecorderSettings);
            });
            Instance._dic[outputFile] = new RecorderController(recorderControllerSettings);
            Instance._dic[outputFile].PrepareRecording();
            var success = Instance._dic[outputFile].StartRecording();
            Debug.Log($"start recording. success={success}");
        }

        /// <summary>
        /// 記録終了
        /// </summary>
        public static void StopRecording(CaptureRecorderSetting setting)
        {
            var outputFile = setting.FilePath;
            if (!Instance._dic.ContainsKey(outputFile)) return;
            Instance._dic[outputFile].StopRecording();
            Debug.Log("stop recording.");
        }
    }

    /// <summary>
    /// 動画撮影の設定
    /// </summary>
    public struct CaptureRecorderSetting
    {
        public readonly string FilePath;
        public readonly int Width;
        public readonly int Height;

        public CaptureRecorderSetting(string filePath = "Temp/UniToolMovie", int width = 640, int height = 480)
        {
            FilePath = filePath;
            Width = width;
            Height = height;
        }
    }
}
#endif