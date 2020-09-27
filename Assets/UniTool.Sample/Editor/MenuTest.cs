using NUnit.Framework;

namespace UniTool.Sample.Editor
{
    public class MenuTest
    {
        [Test]
        public void SuccessTest()
        {
            Menu.ExportUnityPackage();
            Menu.BuildAssetBundle();
        }
    }
}