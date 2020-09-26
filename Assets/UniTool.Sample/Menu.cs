using System.IO;
using UniTool.Editor;
using UniTool.Editor.Event;
using UnityEditor;

namespace UniTool.Sample
{
    public static class Menu
    {
        [MenuItem("UniTool/Export UnityPackage")]
        public static void ExportUnityPackage()
        {
            UnityPackageExporter.Export();
        }
        
        [MenuItem("UniTool/Build AssetBundle")]
        public static void BuildAssetBundle()
        {
            const string bundleName = "sound1";
            const string assetPath1 = "Assets/UniTool.Sample/SampleSound1.mp3";
            const string assetPath2 = "Assets/UniTool.Sample/SampleSound2.mp3";
            const string outputPath = "Temp/SampleSound";
            
            if (!Directory.Exists(outputPath)) Directory.CreateDirectory(outputPath);
            var assets = new SimpleAssets(bundleName, new[] { assetPath1, assetPath2 });
            SimpleAssetBundle.Build(outputPath, new[] {assets});
        }
    }
}