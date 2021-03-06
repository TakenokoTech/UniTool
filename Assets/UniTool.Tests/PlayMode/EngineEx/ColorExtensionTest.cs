using System;
using NUnit.Framework;
using UniTool.EngineEx;
using UniTool.Tests.PlayMode.TestTool;
using UnityEngine;

namespace UniTool.Tests.PlayMode.EngineEx
{
    public class ColorExtensionTest
    {
        [Test]
        public void ToColorTest()
        {
            Assert.AreEqual(new Color(0,0,0,1), "#000000".ToColor());
            Assert.AreEqual(new Color(1,1,1,1), "#FFFFFF".ToColor());
            
            AssertEx.AreThrow(new ArgumentException($"000000 cannot be converted to color."), () => "000000".ToColor());
            AssertEx.AreThrow(new ArgumentException($"#GGGGGG cannot be converted to color."), () => "#GGGGGG".ToColor());
        }
    }
}
