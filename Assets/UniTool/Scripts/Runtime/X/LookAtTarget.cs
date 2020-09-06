using UnityEngine;

namespace UniTool.Scripts.Runtime.X
{
    public class LookAtTarget : MonoBehaviour
    {
        [SerializeField] public Transform target;
        [SerializeField] private Vector3 offsetPosition = Vector3.zero;
        [SerializeField] private Vector3 offsetRotation = Vector3.zero;

        private void Update()
        {
            transform.position = target.position + offsetPosition;
            transform.LookAt(target);
            transform.rotation *= Quaternion.Euler(offsetRotation);
        }
    }
}
