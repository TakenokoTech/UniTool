using UnityEngine;
using UniTool.EngineEx;
using UniTool.ObjectEx;

namespace UniTool.Event
{
    /// <summary>
    /// 簡易サウンド再生
    /// </summary>
    public static class SimpleAudio
    {
        private const string BaseName = "[UniTool] SimpleAudio";

        /// <summary>
        /// サウンド再生
        /// </summary>
        public static void Play(AudioClip clip, string tag = "")
        {
            if (clip == null) return;
            var source = GetAudioSource(tag);
            source.transform.position = Vector3.zero;
            source.spatialBlend = 0.0F;
            source.PlayOneShot(clip);
        }
        
        /// <summary>
        /// 3Dサウンド再生
        /// </summary>
        public static void Play3D(AudioClip clip, Vector3 position, string tag = "")
        {
            if (clip == null) return;
            var source = GetAudioSource(tag);
            source.transform.position = position;
            source.spatialBlend = 1.0F;
            source.minDistance = 1.5F;
            source.PlayOneShot(clip);
        }

        private static AudioSource GetAudioSource(string tag)
        {
            var audio = new GameObject($"{BaseName} ({tag})");
            audio.AddComponent<SimpleAudioMono>();
            return audio.AddComponent<AudioSource>();
        }
        
        private class SimpleAudioMono : MonoBehaviour
        {
            private AudioSource _source = null;

            private void Start()
            {
                _source = GetComponent<AudioSource>();
                DontDestroyOnLoad(gameObject);
            }

            private void Update()
            {
                if(!_source.isPlaying) gameObject.Destroy();
            }
        }
    }
}