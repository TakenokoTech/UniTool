using System;
using UnityEngine;

namespace UniTool.Scripts.Runtime.X
{
    [RequireComponent(typeof(Camera))]
    public class CameraStabilizer : MonoBehaviour
    {
        [SerializeField] private bool lockX = false;
        [SerializeField] private bool lockY = false;
        [SerializeField] private bool lockZ = false;
        [SerializeField] private float rotateSpeed = 1f;

        private Quaternion _rotation;
        private Vector3 Ang => transform.eulerAngles;

        private void LateUpdate()
        {
            transform.rotation = Quaternion.Slerp(_rotation, transform.rotation, rotateSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(lockX ? 0 : Ang.x, lockY ? 0 : Ang.y, lockZ ? 0 : Ang.z);
            _rotation = transform.rotation;
        }
    }
}
