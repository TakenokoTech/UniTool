using NUnit.Framework;

namespace UniTool.Sample.Editor
{
    public class MenuTest
    {
        [Test]
        public void ExportUnityPackageTest()
        {
            UnitoolMenu.ExportUnityPackage();
        }
        
        [Test]
        public void BuildAssetBundleTest()
        {
            UnitoolMenu.BuildAssetBundle();
        }
    }
}