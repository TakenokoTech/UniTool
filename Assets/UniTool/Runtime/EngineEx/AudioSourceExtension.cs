using UniTool.ObjectEx;
using UnityEngine;
using UnityEngine.Audio;

namespace UniTool.EngineEx
{
    /// <summary>
    /// UnityEngine.AudioSource の拡張メソッド
    /// </summary>
    public static class AudioSourceExtension
    {
        public static AudioSource SetClip(this AudioSource self, AudioClip audioClip) => self.Apply(it => it.clip = audioClip);
        
        public static AudioSource SetOutput(this AudioSource self, AudioMixerGroup group) => self.Apply(it => it.outputAudioMixerGroup = group);
        
        public static AudioSource Mute(this AudioSource self) => self.Apply(it => it.mute = true);
        
        public static AudioSource Unmute(this AudioSource self) => self.Apply(it => it.mute = false);
        
        public static AudioSource SetVolume(this AudioSource self, float volume) => self.Apply(it => it.volume = volume);
        
        public static AudioSource SetPitch(this AudioSource self, float pitch) => self.Apply(it => it.pitch = pitch);
    }
}