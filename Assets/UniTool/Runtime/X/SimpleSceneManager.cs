using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UniTool.ObjectEx;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UniTool.X
{
    /// <summary>
    /// [MonoBehaviour]
    /// シーンの読み込み
    /// </summary>
    public class SimpleSceneManager : MonoBehaviour
    {
        /// <summary>次のシーン</summary>
        public string nextSceneName = "";
        
        /// <summary>リセットするシーン</summary>
        public string rootSceneName = "";
        
        /// <summary>次のシーンにいく時に削除するシーン</summary>
        public List<string> deleteScene = new List<string>();
        
        /// <summary>onAwakeで次のシーンを呼ぶか</summary>
        public bool onAwake = false;

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