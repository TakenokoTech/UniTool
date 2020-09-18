# Sample Code

## EventBus

監視型のイベントシステム

```C#
using UniTool.Event;

class SampleClass : IEventReceiver<TestEvent> {

    void Start()
    {
        EventBus.Register(this);
    }

    void OnDestroy()
    {
        EventBus.UnRegister(this);
    }

    /* override */ void OnEvent(TestEvent e)
    {
        /* implementation */
    }
}

struct TestEvent : IEvent
{
    /* implementation */
}

class PostClass
{
    Update()
    {
        EventBus.Post(new TestEvent { {/* implementation */ });
    }
}
```

