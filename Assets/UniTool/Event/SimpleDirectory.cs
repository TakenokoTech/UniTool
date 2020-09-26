using System.IO;

namespace UniTool.Event
{
    public static class SimpleDirectory
    {
        /**
         * ディレクトリの再起削除
         */
        public static void DeleteDir(string targetDirectoryPath)
        {
            if (!Directory.Exists(targetDirectoryPath)) return;
            foreach (var filePath in Directory.GetFiles(targetDirectoryPath))
            {
                File.SetAttributes(filePath, FileAttributes.Normal);
                File.Delete(filePath);
            }
            foreach (var directoryPath in Directory.GetDirectories(targetDirectoryPath))
            {
                DeleteDir(directoryPath);
            }
            Directory.Delete(targetDirectoryPath, false);
        }
    }
}