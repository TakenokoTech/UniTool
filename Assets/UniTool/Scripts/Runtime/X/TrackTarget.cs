using UnityEngine;

namespace UniTool.Scripts.Runtime.X
{
    public class TrackTarget : MonoBehaviour
    {
        [SerializeField] public Transform target;
        [SerializeField] private Vector3 offsetPosition = Vector3.zero;
        [SerializeField] private Vector3 offsetRotation = Vector3.zero;
        
        private void Update()
        {
            transform.position = target.position + offsetPosition;
            transform.rotation = target.rotation * Quaternion.Euler(offsetRotation);
        }
    }
}
