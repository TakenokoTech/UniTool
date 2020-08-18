using UniTool.Scripts.Runtime.Extension.Object;
using UnityEngine;

namespace UniTool.Scripts.Runtime.GameObject
{
    public static class RigidBodyExtension
    {
        public static Rigidbody GetRigidBody(this UnityEngine.GameObject gameObject) => gameObject.GetComponent<Rigidbody>();
        
        public static Rigidbody SetMass<T>(this Rigidbody rigidBody, float mass) => rigidBody.Apply(it => it.mass = mass);
    }
}