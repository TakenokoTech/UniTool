using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace UniTool.Editor
{
    public static class UnityPackageExporter
    {
        private const string Root = "UniTool";
        private const string DistDir = "Dist";
        private const string SearchPattern = "*";

        public static void Export()
        {
            var exportPath = GetExportPath();
            var assets = GetAssets();
            
            Debug.Log("Export below files" + Environment.NewLine + string.Join(Environment.NewLine, assets));
            ExportPackage(exportPath, assets);
            ExportVersion($"{DistDir}/version");
            Debug.Log("Export complete: " + Path.GetFullPath(exportPath));
        }
        
        public static string GetExportPath()
        {
            var version = Environment.GetEnvironmentVariable("UNITY_PACKAGE_VERSION");
            var fileName = string.IsNullOrEmpty(version) ? "UniTool.unitypackage" : $"UniTool.{version}.unitypackage";
            return $"{DistDir}/{fileName}";
        }

        public static string[] GetAssets()
        {
            var path = Path.Combine(Application.dataPath, Root);
            var assets = Directory.EnumerateFiles(path, SearchPattern, SearchOption.AllDirectories)
                .Where(x => Path.GetExtension(x) == ".cs" || Path.GetExtension(x) == ".meta" || Path.GetExtension(x) == ".asmdef")
                .Select(x => "Assets" + x.Replace(Application.dataPath, "").Replace(@"\", "/"))
                .ToArray();
            return assets;
        }
        
        public static string ExportPackage(string exportPath, string[] assets)
        {
            var dir = new FileInfo(exportPath).Directory;
            if (dir != null && !dir.Exists) dir.Create();
            
            AssetDatabase.ExportPackage(assets, exportPath, ExportPackageOptions.Default);
            return Path.GetFullPath(exportPath);
        }

        public static string ExportVersion(string exportPath)
        {
            var dir = new FileInfo(exportPath).Directory;
            if (dir != null && !dir.Exists) dir.Create();
            
            File.WriteAllText(exportPath, "UniTool");
            return Path.GetFullPath(exportPath);
        }
    }
}
