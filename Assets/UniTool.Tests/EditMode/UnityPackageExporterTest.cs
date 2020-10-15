using System.Linq;
using NUnit.Framework;
using UniTool.Editor;

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
            Assert.True(assets.Any(it => it.Equals("Assets/UniTool/EngineEx.meta")));
            Assert.True(assets.Any(it => it.Equals("Assets/UniTool/Event.meta")));
            Assert.True(assets.Any(it => it.Equals("Assets/UniTool/ObjectEx.meta")));
            Assert.True(assets.Any(it => it.Equals("Assets/UniTool/X.meta")));
        }
        
        [Test] 
        public void ExportPackageTest()
        {
            var path = UnityPackageExporter.ExportPackage("Temp/test", new[]{ "Assets/UniTool.Sample/SampleScene.unity" });
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
