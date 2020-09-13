using System;
using System.Data;
using NUnit.Framework;
using UniTool.ObjectEx;
using UnityEngine;

namespace UniTool.Tests.PlayMode.TestTool
{
    public static class AssertEx
    {
        public static void AreThrow(Exception expected, Action block)
        {
            try
            {
                block();
                Assert.Null(expected);
            }
            catch (Exception actual)
            {
                Assert.AreEqual(expected.GetClassName(), actual.GetClassName());
                Assert.AreEqual(expected.Message, actual.Message);
            }
        }
        
        public static void AssertLessForVector3(Vector3 vector3, float arg2)
        {
            Assert.Less(vector3.x, arg2);
            Assert.Less(vector3.y, arg2);
            Assert.Less(vector3.z, arg2);
        }
        
        public static void AssertAreEqualForVector3(Vector3 arg1, Vector3 arg2, float delta)
        {
            Assert.AreEqual(arg1.x, arg2.x, delta);
            Assert.AreEqual(arg1.y, arg2.y, delta);
            Assert.AreEqual(arg1.z, arg2.z, delta);
        }
    }

    public class AssertExTest
    {
        [Test]
        public void ThrowTest()
        {
            AssertEx.AreThrow(new ArgumentException(null), () => throw new ArgumentException(null));
            AssertEx.AreThrow(new DataException("a is not b"), () => throw new DataException("a is not b"));

            AssertEx.AreThrow(null, () => { });
        }
    }
}