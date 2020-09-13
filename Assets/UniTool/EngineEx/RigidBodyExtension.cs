using UniTool.ObjectEx;
using UnityEngine;

namespace UniTool.EngineEx
{
    /// <summary>
    /// UnityEngine.Rigidbody の拡張メソッド
    /// </summary>
    public static class RigidBodyExtension
    {
        /// <summary>GameObject に Rigidbody を追加する</summary>
        public static Rigidbody AddRigidBody(this GameObject gameObject) => gameObject.AddComponent<Rigidbody>();
        
        /// <summary>GameObject から Rigidbody を取得する</summary>
        public static Rigidbody GetRigidBody(this GameObject gameObject) => gameObject.GetComponent<Rigidbody>();
        
        /// <summary>Rigidbody に mass をセットとする</summary>
        public static Rigidbody SetMass(this Rigidbody rigidBody, float mass) => rigidBody.Apply(it => it.mass = mass);
        
        /// <summary>Rigidbody に drag をセットとする</summary>
        public static Rigidbody SetDrag(this Rigidbody rigidBody, float drag) => rigidBody.Apply(it => it.drag = drag);
        
        /// <summary>Rigidbody の useGravity を <c>true</c> にする</summary>
        public static Rigidbody EnableGravity(this Rigidbody rigidBody) => rigidBody.Apply(it => it.useGravity = true);
        
        /// <summary>Rigidbody に useGravity を <c>false</c> にする</summary>
        public static Rigidbody DisableGravity(this Rigidbody rigidBody) => rigidBody.Apply(it => it.useGravity = false);
    }
}