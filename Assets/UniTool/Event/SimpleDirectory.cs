using System.Collections.Generic;
using System.IO;
using UniTool.ObjectEx;

namespace UniTool.Event
{
    public static class SimpleDirectory
    {
        /// <summary>
        /// ディレクトリ作成
        /// </summary>
        public static DirectoryInfo CreateDir(string targetDirectoryPath)
        {
            return !Directory.Exists(targetDirectoryPath) ? Directory.CreateDirectory(targetDirectoryPath) : null;
        }
        
        /// <summary>
        /// ディレクトリのファイル名を再起取得
        /// </summary>
        public static List<string> GetFileName(string targetDirectoryPath)
        {
            var pathList = new List<string>();
            void GetFileName(string dicPath)
            {
                if (!Directory.Exists(dicPath)) return;
                pathList.AddRange(Directory.GetFiles(dicPath));
                Directory.GetDirectories(dicPath).Foreach(GetFileName);
                pathList.Add(dicPath);
            }
            GetFileName(targetDirectoryPath);
            return pathList;
        }
        
        /// <summary>
        /// ディレクトリの再起削除
        /// </summary>
        public static void DeleteDir(string targetDirectoryPath)
        {
            if (!Directory.Exists(targetDirectoryPath)) return;
            Directory.GetFiles(targetDirectoryPath).Foreach(filePath => { File.SetAttributes(filePath, FileAttributes.Normal); });
            Directory.GetFiles(targetDirectoryPath).Foreach(File.Delete);
            Directory.GetDirectories(targetDirectoryPath).Foreach(DeleteDir);
            Directory.Delete(targetDirectoryPath, false);
        }
    }
}