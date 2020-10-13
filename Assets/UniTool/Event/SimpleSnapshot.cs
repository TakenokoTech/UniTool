using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UniTool.Event
{
    public class SimpleSnapshot
    {
        private static readonly SimpleSnapshot Instance = new SimpleSnapshot();
        private readonly Dictionary<Object, IEnumerator> _dic = new Dictionary<Object, IEnumerator>();

        /// <summary>
        /// スナップショット撮影
        /// </summary>
        public static void Take(SnapshotSetting setting)
        {
            if (setting.Camera == null || Instance._dic.ContainsKey(setting.Camera)) return;
            Instance._dic[setting.Camera] = AsyncTake(setting, bytes =>
            {
                Debug.Log("capture.");
                File.WriteAllBytes(setting.FilePath, bytes);
                Instance._dic.Remove(setting.Camera);
            });
            SimpleCoroutine.StartCoroutine(Instance._dic[setting.Camera]);
        }

        private static IEnumerator AsyncTake(SnapshotSetting setting, Action<byte[]> callback)
        {
            yield return setting.Timing;
            var renderTexture = new RenderTexture(setting.Width, setting.Height, 24, RenderTextureFormat.ARGB32);
            var texture2D = new Texture2D(setting.Width, setting.Height, TextureFormat.ARGB32, false);
            var tempSetting = new TempCameraSetting(setting.Camera);

            setting.Camera.targetTexture = renderTexture;
            setting.Camera.Render();
            RenderTexture.active = renderTexture;
            texture2D.ReadPixels(new Rect(0, 0, setting.Width, setting.Height), 0, 0);

            Object.Destroy(renderTexture);
            tempSetting.RevertSetting(setting.Camera);
            callback(texture2D.EncodeToPNG());
        }

        private struct TempCameraSetting
        {
            private readonly RenderTexture _targetTexture;
            private readonly RenderTexture _renderTextureActive;

            public TempCameraSetting(Camera camera)
            {
                _targetTexture = camera.targetTexture;
                _renderTextureActive = RenderTexture.active;
            }

            public void RevertSetting(Camera camera)
            {
                camera.targetTexture = _targetTexture;
                RenderTexture.active = _renderTextureActive;
            }
        }
    }
    
    public struct SnapshotSetting
    {
        public readonly Camera Camera;
        public readonly string FilePath;
        public readonly int Width;
        public readonly int Height;
        public YieldInstruction Timing;

        public SnapshotSetting(Camera camera, string filePath = "Temp/UniToolPicture.png", int width = 1920, int height = 1080)
        {
            Camera = camera;
            FilePath = filePath;
            Width = width;
            Height = height;
            Timing = new WaitForEndOfFrame();
        }
    }
}