using UniTool.ObjectEx;
using UnityEngine;

namespace UniTool.EngineEx
{
    /// <summary>
    /// UnityEngine.Animation の拡張メソッド
    /// </summary>
    public static class AnimationExtension
    {
        /// <summary>GameObject から Animation を取得する</summary>
        public static Animation GetAnimation(this GameObject gameObject) => gameObject.GetComponent<Animation>();

        /// <summary>AnimationClip の legacy を <c>true</c> にする</summary>
        public static AnimationClip EnableLegacy(this AnimationClip clip) => clip.Apply(it => { it.legacy = true; });
        
        /// <summary>AnimationClip の legacy を <c>false</c> にする</summary>
        public static AnimationClip DisableLegacy(this AnimationClip clip) => clip.Apply(it => { it.legacy = false; });
        
        /// <summary>AnimationClip の wrapMode を <c>ClampForever</c> にする</summary>
        public static AnimationClip WrapModeClampForever(this AnimationClip clip) => clip.Apply(it => { it.wrapMode = WrapMode.ClampForever; });
        
        /// <summary>AnimationClip の wrapMode を <c>Loop</c> にする</summary>
        public static AnimationClip WrapModeLoop(this AnimationClip clip) => clip.Apply(it => { it.wrapMode = WrapMode.Loop; });
    }
}