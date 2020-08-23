using System;
using System.Data;
using NUnit.Framework;
using UniTool.Scripts.Runtime.ObjectEx;

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