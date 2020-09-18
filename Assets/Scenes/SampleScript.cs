using System;
using UniTool.Event;
using UnityEngine;

namespace Scenes
{
    public class SampleScript : MonoBehaviour
    {
        [SerializeField] private AudioClip audioClip = null;
        [SerializeField] private Vector3 audioPosition = Vector3.zero;
        [SerializeField] private bool is3DAudio = false;

        private void OnEnable()
        {
            if(is3DAudio)
                SimpleAudio.Play3D(audioClip, audioPosition, audioPosition.ToString());
            else
                SimpleAudio.Play(audioClip);
        }

        private void OnDisable()
        {
            SimpleAudio.DropSource(audioPosition.ToString());
        }
    }
}
