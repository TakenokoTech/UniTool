using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace UniTool.Event
{
    /// <summary>
    /// EventBus の実装
    /// </summary>
    public class EventBus
    {
        private static EventBus _instance;
        private static EventBus Instance => _instance ?? (_instance = new EventBus());
        private readonly List<EventListenerWrapper> _listeners = new List<EventListenerWrapper>();

        /// <summary>
        /// レシーバー登録
        /// </summary>
        public static void Register(IEventReceiverBase target)
        {
            if (Instance._listeners.All(l => l.Listener != target))
            {
                Instance._listeners.Add(new EventListenerWrapper(target));
            }
        }

        /// <summary>
        /// レシーバー解除
        /// </summary>
        public static void Unregister(IEventReceiverBase target)
        {
            Instance._listeners.RemoveAll(l => l.Listener == target);
        }

        /// <summary>
        /// イベント発火
        /// </summary>
        public static void Post(IEvent e)
        {
            Instance._listeners.Where(l => l.EventType == e.GetType()).ToList().ForEach(l => l.PostEvent(e));
        }

        private class EventListenerWrapper
        {
            public IEventReceiverBase Listener { get; }
            public Type EventType { get; }
            private readonly MethodBase _method;

            public EventListenerWrapper(IEventReceiverBase listener)
            {
                Listener = listener;
                _method = listener.GetType().GetMethod("OnEvent");
                if (_method == null) throw new InvalidDataException();

                EventType = _method.GetParameters()[0].ParameterType;
            }

            public void PostEvent(object e) => _method.Invoke(Listener, new[] {e});
        }
    }

    public interface IEventReceiverBase
    {
    }

    public interface IEvent
    {
    }

    /// <code>
    /// class SampleClass : IEventReceiver&lt;TestEvent&gt; {
    ///   void Start() { EventBus.Register(this); }
    ///   void OnDestroy() { EventBus.UnRegister(this); }
    ///   public void OnEvent(TestEvent e) { /* implementation */ } // override
    /// }
    ///
    ///   // post value 
    ///   EventBus.Post(new TestEvent { {value} });
    /// </code>
    public interface IEventReceiver<in T> : IEventReceiverBase where T : struct, IEvent
    {
        void OnEvent(T e);
    }
}