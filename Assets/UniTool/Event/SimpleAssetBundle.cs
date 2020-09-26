using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UniTool.Event
{
    /// <summary>
    /// 簡易AssetBundle読み込み
    /// </summary>
    public class SimpleAssetBundle
    {
        private static readonly SimpleAssetBundle Instance = new SimpleAssetBundle();
        private readonly Dictionary<string, Asset> _assetMap = new Dictionary<string, Asset>();

        public static T Load<T>(string path, string name) where T : Object
        {
            if (!Instance._assetMap.ContainsKey(path))
                Instance._assetMap.Add(path, new Asset {RefCount = 1, Bundle = AssetBundle.LoadFromFile(path)});
            else
                Instance._assetMap[path].RefCount++;
            return Instance._assetMap[path].Bundle.LoadAsset<T>(name);
        }

        public static void Unload(string path)
        {
            if (!Instance._assetMap.ContainsKey(path)) return;
            if (--Instance._assetMap[path].RefCount > 0) return;
            Instance._assetMap[path].Bundle.Unload(false);
            Instance._assetMap.Remove(path);
        }

        public static int? GetRefCount(string path)
        {
            Instance._assetMap.TryGetValue(path, out var asset);
            return asset?.RefCount;
        }

        public static string[] GetAllAssetNames(string path)
        {
            if (!Instance._assetMap.ContainsKey(path))
                Instance._assetMap.Add(path, new Asset {RefCount = 0, Bundle = AssetBundle.LoadFromFile(path)});
            var assets = Instance._assetMap[path].Bundle;
            return assets.GetAllAssetNames();
        }
        
        public static string[] GetAllScenePaths(string path)
        {
            if (!Instance._assetMap.ContainsKey(path))
                Instance._assetMap.Add(path, new Asset {RefCount = 0, Bundle = AssetBundle.LoadFromFile(path)});
            var assets = Instance._assetMap[path].Bundle;
            return assets.GetAllScenePaths();
        }
            
        private SimpleAssetBundle()
        {
        }

        private class Asset
        {
            public int RefCount;
            public AssetBundle Bundle;
        }
    }
}