using UniTool.Event;
using UnityEngine;

namespace UniTool.Sample
{
    public class SampleScript : MonoBehaviour
    {
        [SerializeField] private AudioClip audioClip = null;
        [SerializeField] private Vector3 audioPosition = Vector3.zero;

        private void OnEnable()
        {
            SimpleAudio.Play3D(audioClip, audioPosition, audioPosition.ToString());
            // SimpleAudio.Play(audioClip);
        }

        private void OnDisable()
        {
            // SimpleAudio.DropSource(audioPosition.ToString());
        }
    }
}
