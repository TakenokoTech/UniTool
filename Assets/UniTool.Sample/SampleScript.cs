using System;
using UniTool.Event;
using UnityEngine;

namespace UniTool.Sample
{
    public class SampleScript : MonoBehaviour
    {
        [SerializeField] private AudioClip audioClip = null;
        [SerializeField] private Vector3 audioPosition = Vector3.zero;
        
        [SerializeField] private AnimationClip animationClip = null;
        [SerializeField] private bool isRecoding = false;

        private void OnEnable()
        {
            SimpleAudio.Play3D(audioClip, audioPosition, audioPosition.ToString());
            // SimpleAudio.Play(audioClip);
            
            // SimpleAnimationRecorder.StartRecording(this, animationClip);
            SimpleAnimationRecorder.PlayOnce(this, animationClip);
        }

        private void OnDisable()
        {
            // SimpleAnimationRecorder.StopRecording(this);
        }

        
        //　現在の角度
        private float angle;

        // private void Update()
        // {
        //     if (isRecoding)
        //     {
        //         transform.position = Quaternion.Euler(0f, angle, 0f) * new Vector3(0f, 0f, 2f);
        //         transform.rotation = Quaternion.LookRotation(transform.position, Vector3.up);
        //         angle += 180f * Time.deltaTime;
        //         angle = Mathf.Repeat(angle, 360f);
        //     }
        // }
    }
}
