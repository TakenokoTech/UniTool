using System.Collections;
using UniTool.Tests.PlayMode.TestTool;
using UniTool.X;
using UnityEngine;
using UnityEngine.TestTools;

// ReSharper disable Unity.InefficientPropertyAccess
namespace UniTool.Tests.PlayMode.X
{
    public class LookAtTargetTest
    {
        [UnityTest]
        public IEnumerator AddComponentLookAtTarget()
        {
            var gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            gameObject.transform.position = Vector3.zero;
            gameObject.transform.eulerAngles = Vector3.zero;
            var lookAtTarget = gameObject.AddComponent<LookAtTarget>();
            lookAtTarget.target = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
            yield return null;
            
            gameObject.transform.position = Vector3.one;
            gameObject.transform.eulerAngles = Vector3.one;
            yield return null;
            
            AssertEx.AssertAreEqualForVector3(gameObject.transform.eulerAngles, Vector3.one, 0.01F);
        }
    }
}