using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UniTool.EngineEx;
using UnityEngine;

namespace UniTool.Event
{
    public class SimpleAnimationRecorder
    {
        private static readonly SimpleAnimationRecorder Instance = new SimpleAnimationRecorder();
        private readonly Dictionary<MonoBehaviour, IEnumerator> _dic = new Dictionary<MonoBehaviour, IEnumerator>();

        public static void StartRecording(MonoBehaviour monoBehaviour, AnimationClip animationClip)
        {
            if (animationClip == null) return;
            if (Instance._dic.ContainsKey(monoBehaviour)) return;
            Instance._dic[monoBehaviour] = AsyncStartRecording(monoBehaviour.transform, animationClip);
            monoBehaviour.StartCoroutine(Instance._dic[monoBehaviour]);
        }

        public static void StopRecording(MonoBehaviour monoBehaviour)
        {
            if (!Instance._dic.ContainsKey(monoBehaviour)) return;
            monoBehaviour.StopCoroutine(Instance._dic[monoBehaviour]);
            Instance._dic.Remove(monoBehaviour);
        }

        public static void PlayOnce(MonoBehaviour monoBehaviour, AnimationClip animationClip, IAnimationListener listener = null)
        {
            if (animationClip == null) return;
            const string name = "clip";
            var animation = monoBehaviour.gameObject.AddComponent<Animation>();
            animation.AddClip(animationClip.EnableLegacy().WrapModeClampForever(), name);
            animation.Play(name);
            monoBehaviour.StartCoroutine(AsyncPlay(animation, animationClip, listener));
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
                UpdateAnimation(animationLocalPosition.X,"localPosition.x", localPosition.x);
                UpdateAnimation(animationLocalPosition.Y,"localPosition.y", localPosition.y);
                UpdateAnimation(animationLocalPosition.Z,"localPosition.z", localPosition.z);
                var localRotation = transform.localRotation;
                UpdateAnimation(animationLocalRotation.X,"localRotation.x", localRotation.x);
                UpdateAnimation(animationLocalRotation.Y,"localRotation.y", localRotation.y);
                UpdateAnimation(animationLocalRotation.Z,"localRotation.z", localRotation.z);
                UpdateAnimation(animationLocalRotation.W,"localRotation.w", localRotation.w);
                yield return null;
                currentTime += Time.deltaTime;
            }
        }

        private static IEnumerator AsyncPlay(Animation animation, AnimationClip animationClip, [CanBeNull] IAnimationListener listener)
        {
            while (animation["clip"].length > 0)
            {
                if (animation["clip"].length < animation["clip"].time) break;
                yield return null;
            }
            listener?.OnAnimationFinished(animationClip);
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
    
    public interface IAnimationListener
    {
        void OnAnimationFinished(AnimationClip clip);
    }
}