using NUnit.Framework;
using UniTool.ObjectEx;

namespace Tests.PlayMode.ObjectEx
{
    public class ApplyExtensionTest
    {
        [Test]
        public void Class()
        {
            var empty = new EmptyTestClass();
            var emptyActual = empty.Apply(self => { });
            var emptyExpected = new EmptyTestClass();
            Assert.AreEqual(emptyExpected.Dump(), emptyActual.Dump());
            
            var actual = new TestClassWithField().Apply(self =>
            {
                self.Key1 = "Value1";
                self.Key2 = "Value2";
                self.Key3 = "Value3";
            });
            var expected = new TestClassWithField { Key1 = "Value1", Key2 = "Value2", Key3 = "Value3" };
            Assert.AreEqual(expected.Key1, actual.Key1);
            Assert.AreEqual(expected.Key2, actual.Key2);
            Assert.AreEqual(expected.Key3, actual.Key3);
        }
        
        [Test]
        public void Struct()
        {
            var empty = new EmptyTestStruct();
            var emptyActual = empty.Apply((ref EmptyTestStruct self) => { });
            var emptyExpected = new EmptyTestStruct();
            Assert.AreEqual(emptyExpected, emptyActual);
            
            var actual = new TestStructWithField().Apply((ref TestStructWithField self) =>
            {
                self.Key1 = "Value1";
                self.Key2 = "Value2";
                self.Key3 = "Value3";
            });
            var expected = new TestStructWithField { Key1 = "Value1", Key2 = "Value2", Key3 = "Value3" };
            Assert.AreEqual(expected.Key1, actual.Key1);
            Assert.AreEqual(expected.Key2, actual.Key2);
            Assert.AreEqual(expected.Key3, actual.Key3);
        }
    }
}