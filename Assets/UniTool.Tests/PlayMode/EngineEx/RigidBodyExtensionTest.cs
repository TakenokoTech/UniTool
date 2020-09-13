using System.Collections;
using NUnit.Framework;
using UniTool.EngineEx;
using UnityEngine;
using UnityEngine.TestTools;

namespace UniTool.Tests.PlayMode.EngineEx
{
    public class RigidBodyExtensionTest
    {
        [UnityTest]
        public IEnumerator GetterTest()
        {
            var gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            yield return null;
            var rigidBody1 = gameObject.GetRigidBody();
            Assert.Null(rigidBody1);
            
            gameObject.AddRigidBody();
            yield return null;
            var rigidBody2 = gameObject.GetRigidBody();
            Assert.NotNull(rigidBody2);
        }

        [UnityTest]
        public IEnumerator SetterTest()
        {
            var gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            var rigidBody = gameObject.AddRigidBody();
            
            yield return null;
            Assert.AreEqual(100, rigidBody.SetMass(100).mass);
            
            yield return null;
            Assert.AreEqual(100, rigidBody.SetDrag(100).drag);
            
            yield return null;
            Assert.AreEqual(true, rigidBody.EnableGravity().useGravity);
            
            yield return null;
            Assert.AreEqual(false, rigidBody.DisableGravity().useGravity);
        }
    }
}