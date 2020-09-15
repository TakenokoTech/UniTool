using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UniTool.X
{
    public class SimpleSceneManager : MonoBehaviour
    {
        public string nextSceneName;
        public string rootSceneName;
        public List<string> deleteScene = new List<string>();
        public bool onAwake;

        private void Awake()
        {
            if (onAwake) Next();
        }

        public void Next()
        {
            var nowSceneList = SceneList();

            foreach (var scene in deleteScene)
                if (nowSceneList.Contains(scene))
                {
                    SceneManager.UnloadSceneAsync(scene);
                }

            if (!string.IsNullOrEmpty(nextSceneName))
                if (!nowSceneList.Contains(nextSceneName))
                {
                    SceneManager.LoadScene(nextSceneName, LoadSceneMode.Additive);
                }
        }

        public void Finish()
        {
            SceneManager.LoadScene(rootSceneName, LoadSceneMode.Single);
        }

        private static List<string> SceneList()
        {
            var list = new List<string>();
            for (var i = 0; i < SceneManager.sceneCount; i++)
            {
                list.Add(SceneManager.GetSceneAt(i).name);
            }
            return list;
        }
    }
}