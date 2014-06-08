using System;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;

namespace SentinelSystemControlWatchdog
{
    class SentinelSystemControlWatchdog
    {
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr windowPtr, int nCmdShow);

        static void Main(string[] args)
        {
            Initialize();
            Start();
        }

        /// <summary>
        /// Initializes the program.
        /// </summary>
        private static void Initialize()
        {
            const string windowName = "SentinelSystemControlWatchdog";

            Console.Title = windowName;

            // Hide the window
            IntPtr windowPtr = FindWindow(null, windowName);
            ShowWindow(windowPtr, 0); // 0 = hide, 1 = show
        }

        /// <summary>
        /// Starts the watch dog.
        /// </summary>
        private static void Start()
        {
            long memory = 0;

            while (true)
            {
                var processes = Process.GetProcessesByName("SentinelSystemControl");

                try
                {
                    memory = processes[0].PrivateMemorySize64;
                    Logger.Log(String.Format("Memory used: {0}.", memory));
                }
                catch (IndexOutOfRangeException)
                {
                    Logger.Log("Process not found!", LogType.Error);
                }

                if (memory > 200000000) // Normal usage ~52'000'000
                {
                    processes[0].Kill();
                    Logger.Log("SentinelSystemControl process killed!", LogType.Warning);
                }

                Thread.Sleep(TimeSpan.FromSeconds(10));
            }
        }
    }
}
