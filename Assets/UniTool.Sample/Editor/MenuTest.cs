using NUnit.Framework;

namespace UniTool.Sample.Editor
{
    public class MenuTest
    {
        [Test]
        public void ExportUnityPackageTest()
        {
            Menu.ExportUnityPackage();
        }
        
        [Test]
        public void BuildAssetBundleTest()
        {
            Menu.BuildAssetBundle();
        }
    }
}