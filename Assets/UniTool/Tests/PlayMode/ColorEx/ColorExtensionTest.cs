using System;
using NUnit.Framework;
using UniTool.Scripts.Runtime.ColorEx;
using UniTool.Tests.PlayMode.TestTool;
using UnityEngine;

namespace UniTool.Tests.PlayMode.ColorEx
{
    public class ColorExtensionTest
    {
        [Test]
        public void ToColorTest()
        {
            Assert.AreEqual(new Color(0,0,0,1), "#000001".ToColor());
            Assert.AreEqual(new Color(1,1,1,1), "#FFFFFF".ToColor());
            
            AssertEx.AreThrow(new ArgumentException($"000000 cannot be converted to color."), () => "000000".ToColor());
            AssertEx.AreThrow(new ArgumentException($"#GGGGGG cannot be converted to color."), () => "#GGGGGG".ToColor());
        }
    }
}
