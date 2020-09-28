using System.Collections.Generic;
using System.Linq;
using UniTool.ObjectEx;

namespace UniTool.Event
{
    /// <summary>
    /// EventBus の実装
    /// </summary>
    public class SimpleEventBus
    {
        private static readonly SimpleEventBus Instance = new SimpleEventBus();
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
            Instance._listeners.Where(l => l.SameEvent(e)).ToList().ForEach(l => l.PostEvent(e));
        }

        private class EventListenerWrapper
        {
            public IEventReceiverBase Listener { get; }

            public EventListenerWrapper(IEventReceiverBase listener)
            {
                Listener = listener;
            }

            public bool SameEvent(object e) => Listener.GetParametersType("OnEvent", 0) == e.GetType();
            public void PostEvent(object e) => Listener.Invoke("OnEvent", e);
        }
        
        private SimpleEventBus() {}
    }

    /// <summary>
    /// レシーバーのベースとなるインタフェース
    /// </summary>
    public interface IEventReceiverBase
    {
    }

    /// <summary>
    /// レシーブするデータに実装するインタフェース
    /// </summary>
    public interface IEvent
    {
    }

    /// <summary>
    /// レシーブするクラスに実装するインタフェース
    /// </summary>
    public interface IEventReceiver<in T> : IEventReceiverBase where T : struct, IEvent
    {
        void OnEvent(T e);
    }
}