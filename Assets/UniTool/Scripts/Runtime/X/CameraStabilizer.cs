using System;
using UnityEngine;

namespace UniTool.Scripts.Runtime.X
{
    [RequireComponent(typeof(Camera))]
    public class CameraStabilizer : MonoBehaviour
    {
        [SerializeField] private bool lockX;
        [SerializeField] private bool lockY;
        [SerializeField] private bool lockZ;
        [SerializeField] private float rotateSpeed = 1f;
        
        [SerializeField] Vector3 diffQuat;
        
        private Quaternion _rotation;
        private Vector3 Ang => transform.eulerAngles;

        private void LateUpdate()
        {
            transform.rotation = Quaternion.Slerp(_rotation, transform.rotation, rotateSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(lockX ? 0 : Ang.x, lockY ? 0 : Ang.y, lockZ ? 0 : Ang.z);

            diffQuat = _rotation.eulerAngles - Ang;
            _rotation = transform.rotation;
        }
    }
}
