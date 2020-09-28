using System;
using System.IO;
using NUnit.Framework;
using UniTool.Event;
using UnityEngine;

namespace UniTool.Tests.PlayMode.Event
{
    public class SimpleDirectoryTest
    {
        [Test]
        public void CreateAndRemoveTest()
        {
            var targetDirectory = Application.streamingAssetsPath + "/InitTestDirectory";
            
            var info1 = SimpleDirectory.CreateDir(targetDirectory);
            Assert.IsNotNull(info1);
            Assert.AreEqual(1, SimpleDirectory.GetFileName(targetDirectory).Count);
            
            var info2 = SimpleDirectory.CreateDir(targetDirectory);
            Assert.IsNull(info2);
            Assert.AreEqual(1, SimpleDirectory.GetFileName(targetDirectory).Count);
            
            var info3 = SimpleDirectory.CreateDir(targetDirectory + "/testdir");
            Assert.IsNotNull(info3);
            Assert.AreEqual(2, SimpleDirectory.GetFileName(targetDirectory).Count);
            
            File.WriteAllText(targetDirectory + "/a.json", JsonUtility.ToJson(new TestJson("value1", "value2")));
            Assert.AreEqual(3, SimpleDirectory.GetFileName(targetDirectory).Count);
            
            SimpleDirectory.DeleteDir(targetDirectory);
            Assert.AreEqual(0, SimpleDirectory.GetFileName(targetDirectory).Count);
        }
        
        [Serializable]
        private struct TestJson
        {
            [SerializeField] private string key1;
            [SerializeField] private string key2;

            public TestJson(string key1, string key2)
            {
                this.key1 = key1;
                this.key2 = key2;
            }
        } 
    }
}