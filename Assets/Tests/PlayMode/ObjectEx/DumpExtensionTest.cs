using NUnit.Framework;
using UniTool.ObjectEx;

namespace Tests.PlayMode.ObjectEx
{
    public class DumpExtensionTest
    {
        [Test]
        public void Class()
        {
            var empty = new EmptyTestClass();
            var emptyActual = empty.Dump();
            Assert.AreEqual("{}", emptyActual);
            
            var obj1 = new TestClassWithField { Key1 = "Value1", Key2 = "Value2", Key3 = "Value3" };
            var actual1 = obj1.Dump();
            Assert.AreEqual("{Key1=Value1,Key2=Value2,Key3=Value3}", actual1);
            
            var obj2 = new TestClassWithField();
            var actual2 = obj2.Dump();
            Assert.AreEqual("{Key1=,Key2=,Key3=}", actual2);
            
            var obj3 = new TestClassWithProperty { Property1 = "Value1", Property2 = "Value2" };
            var actual3 = obj3.Dump();
            Assert.AreEqual("{Property1=Value1,Property2=Value2}", actual3);

            var obj4 = new TestClassWithFieldProperty {Key1 = "Value1", Property2 = "Value2"};
            var actual4 = obj4.Dump();
            Assert.AreEqual("{Key1=Value1,Property2=Value2}", actual4);
        }

        [Test]
        public void Struct()
        {
            var empty = new EmptyTestStruct();
            var emptyActual = empty.Dump();
            Assert.AreEqual("{}", emptyActual);
            
            var obj1 = new TestStructWithField { Key1 = "Value1", Key2 = "Value2", Key3 = "Value3" };
            var actual1 = obj1.Dump();
            Assert.AreEqual("{Key1=Value1,Key2=Value2,Key3=Value3}", actual1);
            
            var obj2 = new TestStructWithField();
            var actual2 = obj2.Dump();
            Assert.AreEqual("{Key1=,Key2=,Key3=}", actual2);
            
            var obj3 = new TestStructWithProperty { Property1 = "Value1", Property2 = "Value2" };
            var actual3 = obj3.Dump();
            Assert.AreEqual("{Property1=Value1,Property2=Value2}", actual3);
            
            var obj4 = new TestStructWithFieldProperty {Key1 = "Value1", Property2 = "Value2"};
            var actual4 = obj4.Dump();
            Assert.AreEqual("{Key1=Value1,Property2=Value2}", actual4);
        }
    }
}