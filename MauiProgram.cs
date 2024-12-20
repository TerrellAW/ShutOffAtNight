using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Handlers;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace ShutOffAtNight
{
    public static class MauiProgram
    {
        // Public static variables
        public static int InputMinutes;
        public static bool IsTimerRunning = false;
        public static bool IsShuttingDown = false;

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                })
                .ConfigureMauiHandlers(handlers =>
                {
                    handlers.AddHandler<Microsoft.Maui.IImage, IImageHandler>();
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
