using System;
using System.IO;
using NUnit.Framework;
using UniTool.ObjectEx;
using UniTool.Tests.PlayMode.TestTool;

namespace UniTool.Tests.PlayMode.ObjectEx
{
    public class TypeExtensionTest
    {
        [Test]
        public void GetClassNameTest()
        {
            var sample1 = new Sample1();
            Assert.AreEqual("Sample1", sample1.GetClassName());
        }

        [Test]
        public void GetParametersTypeTest()
        {
            var sample1 = new Sample1();
            Assert.AreEqual(typeof(string), sample1.GetParametersType("Method1", 0));
            Assert.AreEqual(typeof(int), sample1.GetParametersType("Method1", 1));
            AssertEx.AreThrow(new InvalidDataException(), () => sample1.GetParametersType("Method2", 1));
            AssertEx.AreThrow(new IndexOutOfRangeException(), () => sample1.GetParametersType("Method1", 3));
        }

        [Test]
        public void InvokeTest()
        {
            var sample1 = new Sample1();
            Assert.AreEqual("A1000", sample1.Invoke("Method1", "A", 1000));
            AssertEx.AreThrow(new InvalidDataException(), () => sample1.Invoke("method2", "B", 2000));
            AssertEx.AreThrow(new InvalidDataException(), () => sample1.Invoke("method1", 2000));
        }

        private class Sample1
        {
            public string Method1(string arg1, int arg2) => arg1 + arg2;
        }
    }
}