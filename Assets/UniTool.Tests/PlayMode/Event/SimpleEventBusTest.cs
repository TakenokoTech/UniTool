using NUnit.Framework;
using UniTool.Event;

namespace UniTool.Tests.PlayMode.Event
{
    public class SimpleEventBusTest
    {
        [Test]
        public void PostTest()
        {
            var test1 = new TestClass1();
            var test2 = new TestClass2();
            SimpleEventBus.Register(test1);
            SimpleEventBus.Register(test2);
            SimpleEventBus.Post(new TestEvent {Str = "A", Num = 1000});

            Assert.AreEqual("A1", test1.Str);
            Assert.AreEqual(1001, test1.Num);
            Assert.AreEqual("A2", test2.Str);
            Assert.AreEqual(1002, test2.Num);

            SimpleEventBus.Unregister(test1);
            SimpleEventBus.Post(new TestEvent {Str = "B", Num = 2000});

            Assert.AreEqual("A1", test1.Str);
            Assert.AreEqual(1001, test1.Num);
            Assert.AreEqual("B2", test2.Str);
            Assert.AreEqual(2002, test2.Num);
        }

        private class TestClass1 : IEventReceiver<TestEvent>
        {
            public string Str = null;
            public float? Num = null;

            public void OnEvent(TestEvent e)
            {
                Str = e.Str + "1";
                Num = e.Num + 1;
            }
        }

        private class TestClass2 : IEventReceiver<TestEvent>
        {
            public string Str = null;
            public float? Num = null;

            public void OnEvent(TestEvent e)
            {
                Str = e.Str + "2";
                Num = e.Num + 2;
            }
        }

        private struct TestEvent : IEvent
        {
            public string Str;
            public float Num;
        }
    }
}