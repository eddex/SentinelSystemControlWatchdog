using System;
using System.IO;

namespace SentinelSystemControlWatchdog
{
    public static class Logger
    {
        private const string FileName = "SentinelSystemControlWatchdog.log";
        private static readonly string DirectoryPath = String.Format("{0}\\{1}", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SentinelSystemControlWatchdog");
        private static readonly string FilePath = Path.Combine(DirectoryPath, FileName);

        public static void Log(string message, LogType type = LogType.Info)
        {
            CreateLogfile();
            SaveLog(message, type);
        }

        private static void CreateLogfile()
        {
            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath);
            }
        }

        private static void SaveLog(string message, LogType type)
        {
            using (var logWriter = new StreamWriter(FilePath, true))
            {
                logWriter.WriteLine("{0} - {1} - {2}", type, DateTime.Now, message);
            }
        }
    }
}
