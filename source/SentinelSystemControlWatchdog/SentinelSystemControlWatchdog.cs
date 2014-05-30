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
            Console.Title = "SentinelSystemControlWatchdog";

            IntPtr windowPtr = FindWindow(null, "SentinelSystemControlWatchdog");

            // Hide the window
            ShowWindow(windowPtr, 0); // 0 = hide, 1 = show

            while (true)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.Clear();
                long memory = 0;
                var processes = Process.GetProcessesByName("SentinelSystemControl");

                try
                {
                    memory = processes[0].PrivateMemorySize64;
                    Console.WriteLine("Memory used: {0}.", memory);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("ERROR: Process not found..");
                }
                if (memory > 100000000) // Normal usage ~52'000'000
                {
                    processes[0].Kill();
                }
            }
        }
    }
}
