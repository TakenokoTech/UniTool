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
            var exportPath = UnityPackageExporter.GetExportPath();
            Assert.AreEqual("Dist/UniTool.unitypackage", exportPath);

            var assets = UnityPackageExporter.GetAssets();
            Assert.True(assets.Any(it => it.Equals("Assets/UniTool/Scripts.meta")));
            Assert.True(assets.Any(it => it.Equals("Assets/UniTool/Scripts/Editor.meta")));
            Assert.True(assets.Any(it => it.Equals("Assets/UniTool/Scripts/Runtime.meta")));
            Assert.True(assets.Any(it => it.Equals("Assets/UniTool/Tests.meta")));
            Assert.True(assets.Any(it => it.Equals("Assets/UniTool/Tests/EditMode.meta")));
            Assert.True(assets.Any(it => it.Equals("Assets/UniTool/Tests/PlayMode.meta")));
            
            UnityPackageExporter.ExportPackage("Temp/test", new[]{ "Assets/UniTool/Scenes/SampleScene.unity" });
        }
    }
}
