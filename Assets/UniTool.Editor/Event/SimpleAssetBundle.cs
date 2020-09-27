using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

// ReSharper disable PossibleMultipleEnumeration
// ReSharper disable SwitchStatementMissingSomeEnumCasesNoDefault
namespace UniTool.Editor.Event
{
    public static class SimpleAssetBundle
    {
        public static AssetBundleManifest Build(string outputPath, IEnumerable<SimpleAssets> assets,
            BuildAssetBundleOptions options = BuildAssetBundleOptions.None,
            BuildTarget target = BuildTarget.NoTarget)
        {
            target = FixTarget(Application.platform, target);
            var buildMap = assets.Select(it => new AssetBundleBuild
                {assetBundleName = it.BundleName, assetNames = it.Assets}).ToArray();
            Debug.Log("Export below files" + Environment.NewLine + string.Join(Environment.NewLine, assets));
            var manifest = BuildPipeline.BuildAssetBundles(outputPath, buildMap, options, target);
            Debug.Log("Export complete: " + Path.GetFullPath(outputPath));
            return manifest;
        }

        public static BuildTarget FixTarget(RuntimePlatform platform, BuildTarget target)
        {
            Debug.Log($"RuntimePlatform.platform: {platform}");
            if (target != BuildTarget.NoTarget) return target;

            switch (platform)
            {
                case RuntimePlatform.OSXEditor:
                    return BuildTarget.StandaloneOSX;
                case RuntimePlatform.WindowsEditor:
                    return BuildTarget.StandaloneWindows;
                case RuntimePlatform.LinuxEditor:
                    return BuildTarget.StandaloneLinux64;
            }

            return target;
        }
    }

    public struct SimpleAssets
    {
        public readonly string BundleName;
        public readonly string[] Assets;

        public SimpleAssets(string bundleName, string[] assets)
        {
            BundleName = bundleName;
            Assets = assets;
        }
    }
}