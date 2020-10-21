using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using UniTool.Logger;
using UniTool.ObjectEx;
using UnityEngine;
using UnityEngine.TestTools;

namespace UniTool.Tests.PlayMode.Logger
{
    public class FileLoggerTest
    {
        [Test]
        public void LogTest()
        {
            LogAssert.ignoreFailingMessages = true;
            File.Delete(FileLogger.LogPath);

            FileLogger.Start();
            Debug.Log($"Log");
            Debug.LogWarning($"LogWarning");
            Debug.LogError($"LogError");
            Debug.LogException(new Exception("LogException"));
            Debug.LogAssertion($"LogAssertion");
            FileLogger.Stop();

            var text = new List<string>();
            using (var sr = new StreamReader(FileLogger.LogPath, Encoding.GetEncoding("Shift_JIS")))
            {
                var line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    text.Add(line.RunCatching(it => it.Remove(0, 20)).GetOrDefault(""));
                }
            }
            
            Assert.AreEqual($"[Log] Log", text[0]);
            Assert.AreEqual($"[Warning] LogWarning", text[1]);
            Assert.AreEqual($"[Error] LogError", text[2]);
            Assert.AreEqual($"[Exception] Exception: LogException", text[3]);
            Assert.AreEqual($"[Assert] LogAssertion", text[4]);
            LogAssert.ignoreFailingMessages = false;
        }

        [Test]
        public void LoggingListenerTest()
        {
            FileLogger.SetLoggingListener((type, condition) => { });
        }
    }
}