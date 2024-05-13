﻿using Microsoft.Extensions.Logging;
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
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("FontAwesomeRegular.otf", "FontRegular");
                    fonts.AddFont("FontAwesomeBrands.otf", "FontBrands");
                    fonts.AddFont("FontAwesomeSolid.otf", "FontSolid");
                });
            builder.ConfigureSyncfusionCore();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
