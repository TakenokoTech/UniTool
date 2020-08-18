using NUnit.Framework;
using UniTool.Scripts.Runtime.Extension.Object;

namespace UniTool.Tests.PlayMode.Extension.Object
{
    public class DumpExtensionTest
    {
        [Test]
        public void Class()
        {
            var empty = new EmptyTestClass();
            var emptyActual = empty.Dump();
            Assert.AreEqual("{}", emptyActual);
            
            var obj1 = new TestClass { Key1 = "Value1", Key2 = "Value2", Key3 = "Value3" };
            var actual1 = obj1.Dump();
            Assert.AreEqual("{Key1=Value1,Key2=Value2,Key3=Value3}", actual1);
            
            var obj2 = new TestClass();
            var actual2 = obj2.Dump();
            Assert.AreEqual("{Key1=,Key2=,Key3=}", actual2);
        }

        [Test]
        public void Struct()
        {
            var empty = new EmptyTestStruct();
            var emptyActual = empty.Dump();
            Assert.AreEqual("{}", emptyActual);
            
            var obj1 = new TestStruct { Key1 = "Value1", Key2 = "Value2", Key3 = "Value3" };
            var actual1 = obj1.Dump();
            Assert.AreEqual("{Key1=Value1,Key2=Value2,Key3=Value3}", actual1);
            
            var obj2 = new TestStruct();
            var actual2 = obj2.Dump();
            Assert.AreEqual("{Key1=,Key2=,Key3=}", actual2);
        }

        private struct TestStruct
        {
            public string Key1;
            public string Key2;
            public string Key3;
        }
        
        private struct EmptyTestStruct
        {
        }
        
        private class TestClass
        {
            public string Key1;
            public string Key2;
            public string Key3;
        }
        
        private struct EmptyTestClass
        {
        }
    }
}