using System;
using UnityEngine;

namespace UniTool.Scripts.Runtime.X
{
    public class LookAtTarget : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offsetPosition;
        [SerializeField] private Vector3 offsetRotation;

        private void Update()
        {
            transform.position = target.position + offsetPosition;
            transform.LookAt(target);
            transform.rotation *= Quaternion.Euler(offsetRotation);
        }
    }
}
