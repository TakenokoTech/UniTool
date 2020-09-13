using UnityEngine;

namespace UniTool.Scripts.Runtime.X
{
    /// <summary>
    /// [MonoBehaviour]
    /// 対象物に向けて角度を変える
    /// </summary>
    public class LookAtTarget : MonoBehaviour
    {
        /// <summary>対象物</summary>
        [SerializeField] public Transform target;
        
        /// <summary>対象物との距離のオフセット</summary>
        [SerializeField] private Vector3 offsetPosition = Vector3.zero;
        
        /// <summary>対象物との角度のオフセット</summary>
        [SerializeField] private Vector3 offsetRotation = Vector3.zero;

        private void Update()
        {
            transform.position = target.position + offsetPosition;
            transform.LookAt(target);
            transform.rotation *= Quaternion.Euler(offsetRotation);
        }
    }
}
