using System.Collections.Generic;
using UnityEngine;
using UniTool.EngineEx;

namespace UniTool.Event
{
    public class SimpleAudio
    {
        private const string BaseName = "[UniTool] Simple Audio";
        private static SimpleAudio _instance = null;
        private readonly Dictionary<string, AudioSource> _audioSourceMap = null;
        
        public static void Play(AudioClip clip, string tag = "")
        {
            if (clip == null) return;
            GetAudioSource(tag).transform.position = Vector3.zero;
            GetAudioSource(tag).spatialBlend = 0.0F;
            GetAudioSource(tag).PlayOneShot(clip);
        }

        public static void Play3D(AudioClip clip, Vector3 position, string tag = "")
        {
            if (clip == null) return;
            GetAudioSource(tag).transform.position = position;
            GetAudioSource(tag).spatialBlend = 1.0F;
            GetAudioSource(tag).minDistance = 1.5F;
            GetAudioSource(tag).PlayOneShot(clip);
        }

        public static void DropSource(string tag)
        {
            GameObject.Find(GetSoundName(tag)).Destroy();
            _instance?._audioSourceMap?.Remove(tag);
        }

        private SimpleAudio()
        {
            _audioSourceMap = new Dictionary<string, AudioSource>();
        }
        
        public static string GetSoundName(string tag) => $"{BaseName}({tag})";
        
        private static AudioSource GetAudioSource(string tag = "")
        {
            AudioSource GetAudio()
            {
                AudioSource audio = null;
                _instance?._audioSourceMap.TryGetValue(tag, out audio);
                return audio;
            }
            // ReSharper disable PossibleNullReferenceException
            if(_instance == null) _instance = new SimpleAudio();
            if (GetAudio() != null) return GetAudio();
            if (_instance?._audioSourceMap?.ContainsKey(tag) == false) _instance?._audioSourceMap.Add(tag, null);
            if (GetAudio() == null) _instance._audioSourceMap[tag] = GameObject.Find(GetSoundName(tag))?.GetComponent<AudioSource>();
            if (GetAudio() == null) _instance._audioSourceMap[tag] = GameObject.Find(GetSoundName(tag))?.AddComponent<AudioSource>();
            if (GetAudio() == null) _instance._audioSourceMap[tag] = new GameObject(GetSoundName(tag)).AddComponent<AudioSource>();
            return _instance._audioSourceMap[tag];
        }
    }
}