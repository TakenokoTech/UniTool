using System.Linq;
using NUnit.Framework;
using UniTool.Scripts.Editor;
using UnityEngine;

namespace UniTool.Tests.EditMode
{
    public class UnityPackageExporterTest
    {
        [Test]
        public void ExportTest()
        {
            UnityPackageExporter.Export();
        }
        
        [Test] 
        public void GetExportPathTest()
        {
            var exportPath = UnityPackageExporter.GetExportPath();
            Assert.AreEqual("Dist/UniTool.unitypackage", exportPath);
        }
        
        [Test] 
        public void GetAssetsTest()
        {
            var assets = UnityPackageExporter.GetAssets();
            Assert.True(assets.Any(it => it.Equals("Assets/UniTool/Scripts.meta")));
            Assert.True(assets.Any(it => it.Equals("Assets/UniTool/Scripts/Editor.meta")));
            Assert.True(assets.Any(it => it.Equals("Assets/UniTool/Scripts/Runtime.meta")));
            Assert.True(assets.Any(it => it.Equals("Assets/UniTool/Tests.meta")));
            Assert.True(assets.Any(it => it.Equals("Assets/UniTool/Tests/EditMode.meta")));
            Assert.True(assets.Any(it => it.Equals("Assets/UniTool/Tests/PlayMode.meta")));
        }
        
        [Test] 
        public void ExportPackageTest()
        {
            var path = UnityPackageExporter.ExportPackage("Temp/test", new[]{ "Assets/UniTool/Scenes/SampleScene.unity" });
            Assert.False(path.Equals(""));
        }
        
        [Test] 
        public void ExportVersionTest()
        {
            var path = UnityPackageExporter.ExportVersion("Temp/test");
            Assert.False(path.Equals(""));
        }
    }
}
