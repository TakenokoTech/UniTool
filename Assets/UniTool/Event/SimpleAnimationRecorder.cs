using System.Collections;
using System.Collections.Generic;
using UniTool.EngineEx;
using UnityEngine;

namespace UniTool.Event
{
    /// <summary>
    /// 簡易Animation記録
    /// </summary>
    public class SimpleAnimationRecorder
    {
        private const string ClipName = "clip";
        private static readonly SimpleAnimationRecorder Instance = new SimpleAnimationRecorder();
        private readonly Dictionary<MonoBehaviour, IEnumerator> _dic = new Dictionary<MonoBehaviour, IEnumerator>();

        /// <summary>
        /// AnimationClipを記録開始
        /// </summary>
        public static void StartRecording(MonoBehaviour obj, AnimationClip clip)
        {
            if (clip == null) return;
            if (Instance._dic.ContainsKey(obj)) return;
            Instance._dic[obj] = AsyncStartRecording(obj.transform, clip);
            obj.StartCoroutine(Instance._dic[obj]);
        }

        /// <summary>
        /// AnimationClipを記録終了
        /// </summary>
        public static void StopRecording(MonoBehaviour obj)
        {
            if (!Instance._dic.ContainsKey(obj)) return;
            obj.StopCoroutine(Instance._dic[obj]);
            Instance._dic.Remove(obj);
        }

        /// <summary>
        /// AnimationClipを単発再生
        /// </summary>
        public static void PlayOnce(MonoBehaviour obj, AnimationClip clip, IAnimationListener listener = null)
        {
            if (clip == null || obj.gameObject.TryGetComponent<Animation>(out _)) return;
            var animation = obj.gameObject.AddComponent<Animation>();
            animation.AddClip(clip.EnableLegacy().WrapModeClampForever(), ClipName);
            animation.Play(ClipName);
            obj.StartCoroutine(AsyncPlay(animation, listener));
        }

        private static IEnumerator AsyncStartRecording(Transform transform, AnimationClip clip)
        {
            clip.ClearCurves();
            var currentTime = 0f;
            var animationLocalPosition = new AnimationCurve3D();
            var animationLocalRotation = new AnimationCurve3D();

            void UpdateAnimation(AnimationCurve animationCurve, string propertyName, float value)
            {
                animationCurve.AddKey(currentTime, value);
                clip.SetCurve("", typeof(Transform), propertyName, animationCurve);
            }

            while (true)
            {
                var localPosition = transform.localPosition;
                UpdateAnimation(animationLocalPosition.X, "localPosition.x", localPosition.x);
                UpdateAnimation(animationLocalPosition.Y, "localPosition.y", localPosition.y);
                UpdateAnimation(animationLocalPosition.Z, "localPosition.z", localPosition.z);
                var localRotation = transform.localRotation;
                UpdateAnimation(animationLocalRotation.X, "localRotation.x", localRotation.x);
                UpdateAnimation(animationLocalRotation.Y, "localRotation.y", localRotation.y);
                UpdateAnimation(animationLocalRotation.Z, "localRotation.z", localRotation.z);
                UpdateAnimation(animationLocalRotation.W, "localRotation.w", localRotation.w);
                yield return null;
                currentTime += Time.deltaTime;
            }
        }

        private static IEnumerator AsyncPlay(Animation animation, IAnimationListener listener)
        {
            while (animation["clip"].length > 0)
            {
                if (animation["clip"].length < animation[ClipName].time) break;
                yield return null;
            }

            listener?.OnAnimationFinished(animation[ClipName].clip);
            animation.gameObject.RemoveComponent<Animation>();
        }

        private SimpleAnimationRecorder()
        {
        }

        private class AnimationCurve3D
        {
            public readonly AnimationCurve X = new AnimationCurve();
            public readonly AnimationCurve Y = new AnimationCurve();
            public readonly AnimationCurve Z = new AnimationCurve();
            public readonly AnimationCurve W = new AnimationCurve();
        }
    }

    /// <summary>
    /// AnimationClipの再生結果を受け取るインタフェース
    /// </summary>
    public interface IAnimationListener
    {
        /// <summary>AnimationClipの終了を通知</summary>
        void OnAnimationFinished(AnimationClip clip);
    }
}