using UnityEngine;

namespace UniTool.X
{
    /// <summary>
    /// [MonoBehaviour]
    /// カメラの揺れを軽減する
    /// </summary>
    [RequireComponent(typeof(Camera))]
    public class CameraStabilizer : MonoBehaviour
    {
        /// <summary>x軸を固定するか</summary>
        [SerializeField] private bool lockX = false;
        
        /// <summary>y軸を固定するか</summary>
        [SerializeField] private bool lockY = false;
        
        /// <summary>z軸を固定するか</summary>
        [SerializeField] private bool lockZ = false;
        
        /// <summary>遅延の許容値(秒)</summary>
        [SerializeField] private float rotateSpeed = 1f;

        private Quaternion _rotation;
        private Vector3 Ang => transform.eulerAngles;

        private void LateUpdate()
        {
            transform.rotation = Quaternion.Lerp(_rotation, transform.rotation, rotateSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(lockX ? 0 : Ang.x, lockY ? 0 : Ang.y, lockZ ? 0 : Ang.z);
            _rotation = transform.rotation;
        }
    }
}
