using System;
using NUnit.Framework;
using UniTool.ObjectEx;

namespace Tests.PlayMode.ObjectEx
{
    public class TryExtensionTest
    {
        NumberWrapper stubNumber = new NumberWrapper();
        
        [Test]
        public void RunCatchingTest()
        {
            var promise1 = 10000.RunCatching(it => it == 10000 ? "aaaaa" : "bbbbb");
            Assert.True(promise1.IsSuccess);
            Assert.AreEqual("aaaaa", promise1.Value);
            Assert.AreEqual("aaaaa", promise1.GetOrDefault(""));
            Assert.AreEqual(null, promise1.Err);
            
            var promise2 = 10000.RunCatching<int, string>(it => throw new Exception());
            Assert.False(promise2.IsSuccess);
            Assert.AreEqual(null, promise2.Value);
            Assert.AreEqual("", promise2.GetOrDefault(""));
            Assert.AreEqual( new Exception().GetClassName(), promise2.Err.GetClassName());

            var promise3 = 10000.RunCatching(it => new NumberWrapper { Number = it == 10000 ? "100" : "200" });
            Assert.True(promise3.IsSuccess);
            Assert.AreEqual("100", promise3.Value.Number);
            Assert.AreEqual("100", promise3.GetOrDefault(stubNumber).Number);
            Assert.AreEqual(null, promise3.Err);

            var promise4 = 10000.RunCatching<int, NumberWrapper>(it => throw new Exception());
            Assert.False(promise4.IsSuccess);
            Assert.AreEqual(null, promise4.Value.Number);
            Assert.AreEqual(stubNumber, promise4.GetOrDefault(stubNumber));
            Assert.AreEqual( new Exception().GetClassName(), promise4.Err.GetClassName());
        }
        
        private struct NumberWrapper
        {
            public string Number;
        }
    }
}