using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UniTool.EnumerableEx;

namespace UniTool.Tests.PlayMode.EnumerableEx
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

        [Test]
        public void ForeachTest()
        {
            var actual1 = "";
            var list = new List<string> {"A", "B", "C"};
            list.Foreach(it => { actual1 += it; });
            Assert.AreEqual("ABC", actual1);

            var actual2 = "";
            var array = new[] {"A", "B", "C"};
            array.ForeachIndexed((index, value) => { actual2 += index + value; });
            Assert.AreEqual("0A1B2C", actual2);
        }

        [Test]
        public void MapTest()
        {
            var list = new List<string> {"A", null, "B", null, "C"};
            var actual1 = list.Map(it => it + "1").ToList();
            Assert.AreEqual("A1", actual1[0]);
            Assert.AreEqual("1", actual1[1]);
            Assert.AreEqual("B1", actual1[2]);
            Assert.AreEqual("1", actual1[3]);
            Assert.AreEqual("C1", actual1[4]);

            var array = new[] {"A", null, "B", null, "C"};
            var actual2 = array.MapIndexed((index, value) => value + index).ToArray();
            Assert.AreEqual("A0", actual2[0]);
            Assert.AreEqual("1", actual2[1]);
            Assert.AreEqual("B2", actual2[2]);
            Assert.AreEqual("3", actual2[3]);
            Assert.AreEqual("C4", actual2[4]);
        }

        [Test]
        public void FilterNotNullTest()
        {
            var list = new List<string> {"A", null, "B", null, "C"};
            var actual1 = list.FilterNotNull().ToList();
            Assert.AreEqual("A", actual1[0]);
            Assert.AreEqual("B", actual1[1]);
            Assert.AreEqual("C", actual1[2]);

            var array = new[] {"A", null, "B", null, "C"};
            var actual2 = array.FilterNotNull().ToArray();
            Assert.AreEqual("A", actual2[0]);
            Assert.AreEqual("B", actual2[1]);
            Assert.AreEqual("C", actual2[2]);
        }
    }
}