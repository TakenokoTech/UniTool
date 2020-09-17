using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UniTool.ObjectEx;

namespace UniTool.Tests.PlayMode.ObjectEx
{
    public class NumberExtensionTest
    {
        [Test]
        public void UntilTest()
        {
            var actual1 = 100.Until(105).ToList();
            Assert.AreEqual(new List<int> {100, 101, 102, 103, 104}, actual1);

            var actual2 = 105.Until(100).ToList();
            Assert.AreEqual(new List<int>(), actual2);

            var actual3 = 100.Until(100).ToList();
            Assert.AreEqual(new List<int>(), actual3);
            
            var actual4 = 100.Until(105, 2).ToList();
            Assert.AreEqual(new List<int> {100, 102, 104}, actual4);
        }

        [Test]
        public void UpToTest()
        {
            var actual1 = 100.UpTo(105).ToList();
            Assert.AreEqual(new List<int> {100, 101, 102, 103, 104, 105}, actual1);

            var actual2 = 105.UpTo(100).ToList();
            Assert.AreEqual(new List<int>(), actual2);

            var actual3 = 100.UpTo(100).ToList();
            Assert.AreEqual(new List<int> {100}, actual3);
            
            var actual4 = 100.UpTo(105, 2).ToList();
            Assert.AreEqual(new List<int> {100, 102, 104}, actual4);
        }

        [Test]
        public void DownToTest()
        {
            var actual1 = 100.DownTo(105).ToList();
            Assert.AreEqual(new List<int>(), actual1);

            var actual2 = 105.DownTo(100).ToList();
            Assert.AreEqual(new List<int> {105, 104, 103, 102, 101, 100}, actual2);

            var actual3 = 100.DownTo(100).ToList();
            Assert.AreEqual(new List<int> {100}, actual3);
            
            var actual4 = 105.DownTo(100, 2).ToList();
            Assert.AreEqual(new List<int> {105, 103, 101}, actual4);
        }
    }
}