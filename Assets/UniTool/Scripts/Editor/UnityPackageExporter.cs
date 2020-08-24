using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace UniTool.Scripts.Editor
{
    public class UnityPackageExporter : UnityEditor.Editor
    {
        private const string Root = "UniTool";
        private const string DistDir = "Dist";
        
        [MenuItem("Tools/Export Unitypackage")]
        public static void Export()
        {
            var version = Environment.GetEnvironmentVariable("UNITY_PACKAGE_VERSION");
            var fileName = string.IsNullOrEmpty(version) ? "UniTool.unitypackage" : $"UniTool.{version}.unitypackage";
            var exportPath = $"{DistDir}/{fileName}";
            
            var path = Path.Combine(Application.dataPath, Root);
            var assets = Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories)
                .Where(x => Path.GetExtension(x) == ".cs" || Path.GetExtension(x) == ".meta" || Path.GetExtension(x) == ".asmdef")
                .Select(x => "Assets" + x.Replace(Application.dataPath, "").Replace(@"\", "/"))
                .ToArray();
 
            Debug.Log("Export below files" + Environment.NewLine + string.Join(Environment.NewLine, assets));
 
            var dir = new FileInfo(exportPath).Directory;
            if (dir != null && !dir.Exists) dir.Create();
            
            AssetDatabase.ExportPackage(assets, exportPath, ExportPackageOptions.Default);
            File.AppendAllText($"{DistDir}/version", "0.0.1");

            Debug.Log("Export complete: " + Path.GetFullPath(exportPath));
        }
    }
}