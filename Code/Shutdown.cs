using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ShutOffAtNight.Code
{
    internal class Shutdown
    {
        public static async Task ShutDown()
        {
            using var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "shutdown",
                    Arguments = "/s /t 0",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            process.Start();
            await process.WaitForExitAsync();
        }

        public static async Task CancelShutdown()
        {
            using var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "shutdown",
                    Arguments = "/a",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            process.Start();
            await process.WaitForExitAsync();
        }
    }
}
