using System.IO;
using UniTool.Editor;
using UniTool.Editor.Event;
using UnityEditor;

namespace UniTool.Sample
{
    public static class Menu
    {
        [MenuItem("UniTool/Export Unitypackage")]
        public static void ExportUnitypackage()
        {
            UnityPackageExporter.Export();
        }
        
        [MenuItem("UniTool/Build AssetBundle")]
        public static void BuildAssetBundle()
        {
            const string bundleName = "sound1";
            const string assetPath = "Assets/UniTool.Sample/SampleSound.mp3";
            const string outputPath = "Temp/SampleSound";
            
            if (!Directory.Exists(outputPath)) Directory.CreateDirectory(outputPath);
            var assets = new SimpleAssets(bundleName, new[] { assetPath });
            SimpleAssetBundle.Build(outputPath, new[] {assets});
        }
    }
}