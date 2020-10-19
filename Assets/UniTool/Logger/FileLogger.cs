using System;
using System.IO;
using System.Text;
using UnityEngine;

namespace UniTool.Logger
{
    public static class FileLogger
    {
        private static event LoggingListener Listener;

        public static void Start()
        {
            Debug.Log("Start FileLogger.");
            Debug.Log($"outputPath = {LogPath}");
            Application.logMessageReceived += LogMessageReceived;
        }

        public static void Stop()
        {
            Debug.Log("Stop FileLogger.");
            Application.logMessageReceived -= LogMessageReceived;
            LogSaverUtils.Close(LogPath);
        }

        public static void SetLoggingListener(LoggingListener listener)
        {
            Listener += listener;
        }

        // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
        private static void LogMessageReceived(string condition, string stackTrace, LogType type)
        {
            Listener?.Invoke(type, condition);

            switch (type)
            {
                case LogType.Assert:
                    LogSaverUtils.Add(LogPath, condition, "Assert");
                    break;
                case LogType.Log:
                    LogSaverUtils.Add(LogPath, condition, "Log");
                    break;
                case LogType.Warning:
                    LogSaverUtils.Add(LogPath, condition, "Warning");
                    break;
                case LogType.Error:
                    LogSaverUtils.Add(LogPath, condition, "Error");
                    // LogSaverUtils.Add(LogPath, stackTrace, "Error");
                    break;
                case LogType.Exception:
                    LogSaverUtils.Add(LogPath, condition, "Exception");
                    // LogSaverUtils.Add(LogPath, stackTrace, "Exception");
                    break;
            }
        }

        public static string LogPath
        {
            get
            {
                var currDateTime = DateTime.Now;
                var currDateTimeString = $"{currDateTime.Date.Year}-{currDateTime.Date.Month}-{currDateTime.Date.Day}";
                var fileName = $"Log_{currDateTimeString}.log";
                return Path.Combine(Path.GetTempPath(), fileName);
            }
        }
    }

    internal static class LogSaverUtils
    {
        private static readonly object FileLock = new object();

        public static void Add(string filePath, string text, string level)
        {
            lock (FileLock)
            {
                var now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                using (var streamWriter = GetStreamWriter(filePath))
                {
                    streamWriter.WriteLine($"{now} [{level}] {text}");
                }
            }
        }

        public static void Close(string filePath)
        {
            lock (FileLock)
            {
                using (var streamWriter = GetStreamWriter(filePath))
                {
                    streamWriter?.WriteLine(">>>>> Destroy");
                    streamWriter?.WriteLine("");
                }
            }
        }

        private static StreamWriter GetStreamWriter(string filePath)
        {
            return new StreamWriter(filePath, true, Encoding.GetEncoding("Shift_JIS"));
        }
    }

    public delegate void LoggingListener(LogType type, string condition);
}