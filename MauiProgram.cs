using MauiLab.ViewModel;
using Microsoft.Extensions.Logging;
using Sharpnado.Tabs;
using Syncfusion.Maui.Core.Hosting;

namespace MauiLab
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseSharpnadoTabs(loggerEnable: true, debugLogEnable: true)
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("FontAwesomeRegular.otf", "FontRegular");
                    fonts.AddFont("FontAwesomeBrands.otf", "FontBrands");
                    fonts.AddFont("FontAwesomeSolid.otf", "FontSolid");
                });
            builder.ConfigureSyncfusionCore();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<BottomTabbarViewModel>();
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
