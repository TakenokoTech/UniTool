using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UniTool.X;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace UniTool.Tests.PlayMode.X
{
    public class SimpleSceneManagerTest
    {
        [UnityTest]
        public IEnumerator AddComponentSimpleSceneManager()
        {
            var gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            var simpleSceneManager = gameObject.AddComponent<SimpleSceneManager>();
            simpleSceneManager.nextSceneName = "Scene1";
            simpleSceneManager.rootSceneName = "Scene1";
            simpleSceneManager.deleteScene = new List<string> { "Scene1" };
            simpleSceneManager.Next();
            
            yield return null;
            Assert.AreEqual("Scene1", SceneManager.GetSceneAt(1).name);
            
            simpleSceneManager.nextSceneName = "Scene2";
            simpleSceneManager.Next();
            
            yield return null;
            Assert.AreEqual("Scene2", SceneManager.GetSceneAt(1).name);
            
            simpleSceneManager.Finish();
            
            yield return null;
            Assert.AreEqual("Scene1", SceneManager.GetSceneAt(0).name);
        }
    }
}