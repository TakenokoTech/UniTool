using System.IO;
using NUnit.Framework;
using UniTool.Editor.Event;
using UnityEditor;
using UnityEngine;

namespace UniTool.Tests.EditMode.Event
{
    public class SimpleAssetBundleTest
    {
        [Test]
        public void BuildTest()
        {
            const string bundleName1 = "scene";
            const string assetPath1 = "Assets/UniTool.Sample/UnitoolScene1.unity";
            const string assetPath2 = "Assets/UniTool.Sample/UnitoolScene2.unity";
            const string assetPath3 = "Assets/UniTool.Sample/UnitoolScene3.unity";
            
            const string bundleName2 = "sound";
            const string assetPath4 = "Assets/UniTool.Sample/UnitoolSampleSound1.mp3";
            const string assetPath5 = "Assets/UniTool.Sample/UnitoolSampleSound2.mp3";
            
            const string outputPath = "Assets/StreamingAssets/InitTestAssetBundle";

            if (!Directory.Exists(outputPath)) Directory.CreateDirectory(outputPath);
            var assets1 = new SimpleAssets(bundleName1, new[] { assetPath1, assetPath2, assetPath3 });
            var assets2 = new SimpleAssets(bundleName2, new[] { assetPath4, assetPath5 });
            var manifest = SimpleAssetBundle.Build(outputPath, new[] {assets1, assets2});
            
            Assert.AreEqual("scene", manifest.GetAllAssetBundles()[0]);
            Assert.AreEqual("sound", manifest.GetAllAssetBundles()[1]);
        }

        [Test]
        public void FixTargetTest()
        {
            var actual1 = SimpleAssetBundle.FixTarget(RuntimePlatform.OSXEditor, BuildTarget.NoTarget);
            Assert.AreEqual(BuildTarget.StandaloneOSX, actual1);
            
            var actual2 = SimpleAssetBundle.FixTarget(RuntimePlatform.WindowsEditor, BuildTarget.NoTarget);
            Assert.AreEqual(BuildTarget.StandaloneWindows, actual2);
            
            var actual3 = SimpleAssetBundle.FixTarget(RuntimePlatform.LinuxEditor, BuildTarget.NoTarget);
            Assert.AreEqual(BuildTarget.StandaloneLinux64, actual3);
            
            var actual4 = SimpleAssetBundle.FixTarget(RuntimePlatform.OSXPlayer, BuildTarget.NoTarget);
            Assert.AreEqual(BuildTarget.NoTarget, actual4);
            
            var actual5 = SimpleAssetBundle.FixTarget(RuntimePlatform.OSXEditor, BuildTarget.Android);
            Assert.AreEqual(BuildTarget.Android, actual5);
        }
    }
}