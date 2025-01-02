using System.Diagnostics;

namespace ShutOffAtNight
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        // Override the Window creation method
        protected override Window CreateWindow(IActivationState? activationState)
        {
            Window window = base.CreateWindow(activationState);

#if WINDOWS
            window.Created += (sender, e) =>
            {
                // Allow use of Microsoftt.UI.Windowing functions
                var handle = WinRT.Interop.WindowNative.GetWindowHandle(window.Handler.PlatformView);
                var id = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(handle);
                var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(id);

                // Window closing behaviour
                appWindow.Closing += (sender, e) =>
                {
                    foreach (var process in Process.GetProcesses())
                    {
                        if (process.ProcessName.Contains("shutdown") || process.ProcessName.Contains("ShutOffAtNight"))
                        {
                            try
                            {
                                process.Kill(true); // Force kill process and all child processes
                                process.WaitForExit(); // Wait for process to exit
                            }
                            catch
                            {
                            }
                        }
                    };
                };
            };
#endif
            return window;
        }
    }
}
