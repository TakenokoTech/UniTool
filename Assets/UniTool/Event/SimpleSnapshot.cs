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
            if (Instance._dic.ContainsKey(setting.Camera)) return;
            Instance._dic[setting.Camera] = AsyncTake(setting.Camera, setting.Width, setting.Height, bytes =>
            {
                Debug.Log("capture.");
                File.WriteAllBytes(setting.FilePath, bytes);
                Instance._dic.Remove(setting.Camera);
            });
            SimpleCoroutine.StartCoroutine(Instance._dic[setting.Camera]);
        }

        private static IEnumerator AsyncTake(Camera targetCamera, int width, int height, Action<byte[]> callback)
        {
            yield return new WaitForEndOfFrame();
            var renderTexture = new RenderTexture(width, height, 24, RenderTextureFormat.ARGB32);
            var texture2D = new Texture2D(width, height, TextureFormat.ARGB32, false);
            var tempSetting = new TempCameraSetting(targetCamera);

            targetCamera.targetTexture = renderTexture;
            targetCamera.Render();
            RenderTexture.active = renderTexture;
            texture2D.ReadPixels(new Rect(0, 0, width, height), 0, 0);

            Object.Destroy(renderTexture);
            tempSetting.RevertSetting(targetCamera);
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

        public SnapshotSetting(Camera camera, string filePath = "Temp/UniToolPicture.png", int width = 1920, int height = 1080)
        {
            Camera = camera;
            FilePath = filePath;
            Width = width;
            Height = height;
        }
    }
}