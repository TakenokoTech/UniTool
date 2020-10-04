using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UniTool.Event
{
    public class SimpleCaptureRecorder
    {
        private static readonly SimpleCaptureRecorder Instance = new SimpleCaptureRecorder();
        private readonly Dictionary<MonoBehaviour, IEnumerator> _dic = new Dictionary<MonoBehaviour, IEnumerator>();
        
        /// <summary>
        /// 記録開始
        /// </summary>
        public static void StartRecording(MonoBehaviour obj)
        {
            if (Instance._dic.ContainsKey(obj)) return;
            Instance._dic[obj] = AsyncStartRecording(Camera.main,1920, 1080, bytes =>
            {
                File.WriteAllBytes(Application.streamingAssetsPath + "/InitTestCapture/cature.png", bytes);
            });
            obj.StartCoroutine(Instance._dic[obj]);
        }

        /// <summary>
        /// 記録終了
        /// </summary>
        public static void StopRecording(MonoBehaviour obj)
        {
            if (!Instance._dic.ContainsKey(obj)) return;
            obj.StopCoroutine(Instance._dic[obj]);
            Instance._dic.Remove(obj);
        }

        private static IEnumerator AsyncStartRecording(Camera targetCamera, int width, int height, Action<byte[]> callback)
        {
            yield return new WaitForEndOfFrame();
            var renderTexture = new RenderTexture(width, height, 24, RenderTextureFormat.ARGB32);
            var texture2D = new Texture2D(width, height, TextureFormat.ARGB32, false);
            var tempSetting = new TempCameraSetting(targetCamera);

            targetCamera.targetTexture = renderTexture;
            targetCamera.Render();
            RenderTexture.active = renderTexture;
            texture2D.ReadPixels(new Rect(0,0, width,height), 0,0);

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
}