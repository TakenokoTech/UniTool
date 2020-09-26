using System.IO;
using NUnit.Framework;
using UniTool.Editor.Event;

namespace UniTool.Tests.EditMode.Event
{
    public class SimpleAssetBundleTest
    {
        [Test]
        public void Test()
        {
            const string bundleName1 = "scene";
            const string assetPath1 = "Assets/UniTool.Sample/Scene1.unity";
            const string assetPath2 = "Assets/UniTool.Sample/Scene2.unity";
            const string assetPath3 = "Assets/UniTool.Sample/Scene3.unity";
            
            const string bundleName2 = "sound";
            const string assetPath4 = "Assets/UniTool.Sample/SampleSound1.mp3";
            const string assetPath5 = "Assets/UniTool.Sample/SampleSound2.mp3";
            
            const string outputPath = "Assets/StreamingAssets/AssetBundleTest";

            if (!Directory.Exists(outputPath)) Directory.CreateDirectory(outputPath);
            var assets1 = new SimpleAssets(bundleName1, new[] { assetPath1, assetPath2, assetPath3 });
            var assets2 = new SimpleAssets(bundleName2, new[] { assetPath4, assetPath5 });
            var manifest = SimpleAssetBundle.Build(outputPath, new[] {assets1, assets2});
            
            Assert.AreEqual("scene", manifest.GetAllAssetBundles()[0]);
            Assert.AreEqual("sound", manifest.GetAllAssetBundles()[1]);
        }
    }
}