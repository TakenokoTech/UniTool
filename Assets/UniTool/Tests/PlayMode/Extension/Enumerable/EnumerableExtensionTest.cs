using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UniTool.Scripts.Runtime.Extension.Enumerable;

namespace UniTool.Tests.PlayMode.Extension.Enumerable
{
    public class EnumerableExtensionTest
    {
        [Test]
        public void WithIndexTest()
        {
            var list = new List<string> {"A", "B", "C"};
            var indexedList = list.WithIndex().ToList();
            Assert.AreEqual(0, indexedList[0].index);
            Assert.AreEqual(1, indexedList[1].index);
            Assert.AreEqual(2, indexedList[2].index);
            Assert.AreEqual("A", indexedList[0].value);
            Assert.AreEqual("B", indexedList[1].value);
            Assert.AreEqual("C", indexedList[2].value);
            
            var array = new[] {"A", "B", "C"};
            var indexedArray = array.WithIndex().ToArray();
            Assert.AreEqual(0, indexedList[0].index);
            Assert.AreEqual(1, indexedList[1].index);
            Assert.AreEqual(2, indexedList[2].index);
            Assert.AreEqual("A", indexedList[0].value);
            Assert.AreEqual("B", indexedList[1].value);
            Assert.AreEqual("C", indexedList[2].value);
        }
    }
}