using System.Collections;
using UniTool.ObjectEx;
using UnityEngine;

namespace UniTool.Event
{
    public static class SimpleCoroutine
    {
        public static Coroutine StartCoroutine(IEnumerator coroutine)
        {
            return CoroutineWrapper.Instance.StartCoroutine(coroutine);
        }

        private class CoroutineWrapper : MonoBehaviour
        {
            public static CoroutineWrapper Instance => _instance ? _instance : Create();
            private static CoroutineWrapper _instance = null;
            private static CoroutineWrapper Create()
            {
                _instance = new GameObject("[UniTool] SimpleCoroutine")/**.Apply(DontDestroyOnLoad)*/.AddComponent<CoroutineWrapper>();
                return _instance;
            }
        }
    }
}