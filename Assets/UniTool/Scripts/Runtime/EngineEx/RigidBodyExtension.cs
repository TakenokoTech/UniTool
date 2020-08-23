using UniTool.Scripts.Runtime.ObjectEx;
using UnityEngine;

namespace UniTool.Scripts.Runtime.EngineEx
{
    public static class RigidBodyExtension
    {
        public static Rigidbody AddRigidBody(this GameObject gameObject) => gameObject.AddComponent<Rigidbody>();
        public static Rigidbody GetRigidBody(this GameObject gameObject) => gameObject.GetComponent<Rigidbody>();
        public static Rigidbody SetMass(this Rigidbody rigidBody, float mass) => rigidBody.Apply(it => it.mass = mass);
        public static Rigidbody SetDrag(this Rigidbody rigidBody, float drag) => rigidBody.Apply(it => it.drag = drag);
        public static Rigidbody EnableGravity(this Rigidbody rigidBody) => rigidBody.Apply(it => it.useGravity = true);
        public static Rigidbody DisableGravity(this Rigidbody rigidBody) => rigidBody.Apply(it => it.useGravity = false);
    }
}