using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShutOffAtNight.Code
{
    internal class Shutdown
    {
        public static void ShutDown()
        {
            // Shutdown the computer
            System.Diagnostics.Process.Start("shutdown", "/s /t 0");
        }

        public static void CancelShutdown()
        {
            // Cancel the shutdown
            System.Diagnostics.Process.Start("shutdown", "/a");
        }
    }
}
