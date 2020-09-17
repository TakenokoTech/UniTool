using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UniTool.ObjectEx;
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
            foreach (var scene in deleteScene.Where(scene => SceneList().Contains(scene)))
                SceneManager.UnloadSceneAsync(scene);

            if (!string.IsNullOrEmpty(nextSceneName) && !SceneList().Contains(nextSceneName))
                SceneManager.LoadScene(nextSceneName, LoadSceneMode.Additive);
        }

        public void Finish()
        {
            SceneManager.LoadScene(rootSceneName, LoadSceneMode.Single);
        }

        private static List<string> SceneList()
        {
            return 0.Until(SceneManager.sceneCount).Select(i => SceneManager.GetSceneAt(i).name).ToList();
        }
    }
}