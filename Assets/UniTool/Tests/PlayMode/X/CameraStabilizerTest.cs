using System.Collections;
using UniTool.Scripts.Runtime.X;
using UniTool.Tests.PlayMode.TestTool;
using UnityEngine;
using UnityEngine.TestTools;

// ReSharper disable Unity.InefficientPropertyAccess
namespace UniTool.Tests.PlayMode.X
{
    public class CameraStabilizerTest
    {
        [UnityTest]
        public IEnumerator AddComponentCameraStabilizer()
        {
            var gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            gameObject.transform.position = Vector3.zero;
            gameObject.transform.eulerAngles = Vector3.zero;
            gameObject.AddComponent<Camera>();
            gameObject.AddComponent<CameraStabilizer>();
            yield return null;

            gameObject.transform.position = Vector3.one;
            gameObject.transform.eulerAngles = Vector3.one;
            yield return null;
            
            AssertEx.AssertLessForVector3(gameObject.transform.eulerAngles, 1);
        }
    }
}