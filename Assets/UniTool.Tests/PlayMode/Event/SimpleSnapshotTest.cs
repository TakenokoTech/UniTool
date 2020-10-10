using System.Collections;
using NUnit.Framework;
using UniTool.Event;
using UnityEngine;
using UnityEngine.TestTools;

namespace UniTool.Tests.PlayMode.Event
{
    public class SimpleSnapshotTest
    {
        [UnityTest]
        public IEnumerator TakeTest()
        {
            var camera = GameObject.CreatePrimitive(PrimitiveType.Cube).AddComponent<Camera>();
            var dir = Application.streamingAssetsPath + "/InitTestCapture";
            SimpleDirectory.DeleteDir(dir);
            SimpleDirectory.CreateDir(dir);
            Assert.AreEqual(1, SimpleDirectory.GetFileName(dir).Count);
            
            var setting = new SnapshotSetting(camera, $"{dir}/cature.png");
            SimpleSnapshot.Take(setting);
            yield return new WaitForSeconds(1F);
            
            Assert.AreEqual(2, SimpleDirectory.GetFileName(dir).Count);
        }
    }
}