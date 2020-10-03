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
        public static void StartRecording(MonoBehaviour monoBehaviour, AnimationClip animationClip)
        {
            if (animationClip == null) return;
            if (Instance._dic.ContainsKey(monoBehaviour)) return;
            Instance._dic[monoBehaviour] = AsyncStartRecording(monoBehaviour.transform, animationClip);
            monoBehaviour.StartCoroutine(Instance._dic[monoBehaviour]);
        }

        /// <summary>
        /// AnimationClipを記録終了
        /// </summary>
        public static void StopRecording(MonoBehaviour monoBehaviour)
        {
            if (!Instance._dic.ContainsKey(monoBehaviour)) return;
            monoBehaviour.StopCoroutine(Instance._dic[monoBehaviour]);
            Instance._dic.Remove(monoBehaviour);
        }

        /// <summary>
        /// AnimationClipを単発再生
        /// </summary>
        public static void PlayOnce(
            MonoBehaviour monoBehaviour,
            AnimationClip animationClip,
            IAnimationListener listener = null)
        {
            if (animationClip == null) return;
            var animation = monoBehaviour.gameObject.AddComponent<Animation>();
            animation.AddClip(animationClip.EnableLegacy().WrapModeClampForever(), ClipName);
            animation.Play(ClipName);
            monoBehaviour.StartCoroutine(AsyncPlay(animation, listener));
        }

        private static IEnumerator AsyncStartRecording(Transform transform, AnimationClip animationClip)
        {
            animationClip.ClearCurves();
            var currentTime = 0f;
            var animationLocalPosition = new AnimationCurve3D();
            var animationLocalRotation = new AnimationCurve3D();

            void UpdateAnimation(AnimationCurve animationCurve, string propertyName, float value)
            {
                animationCurve.AddKey(currentTime, value);
                animationClip.SetCurve("", typeof(Transform), propertyName, animationCurve);
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