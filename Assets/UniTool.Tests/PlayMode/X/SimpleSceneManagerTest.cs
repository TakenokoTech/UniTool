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
            simpleSceneManager.nextSceneName = "UnitoolScene1";
            simpleSceneManager.rootSceneName = "UnitoolScene1";
            simpleSceneManager.deleteScene = new List<string> { "UnitoolScene1" };
            simpleSceneManager.Next();
            
            yield return null;
            Assert.AreEqual("UnitoolScene1", SceneManager.GetSceneAt(1).name);
            
            simpleSceneManager.nextSceneName = "UnitoolScene2";
            simpleSceneManager.Next();
            
            yield return null;
            Assert.AreEqual("UnitoolScene2", SceneManager.GetSceneAt(1).name);
            
            simpleSceneManager.Finish();
            
            yield return null;
            Assert.AreEqual("UnitoolScene1", SceneManager.GetSceneAt(0).name);
        }
    }
}