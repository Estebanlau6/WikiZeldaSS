using Microsoft.Extensions.Logging;
using WikiZeldaSS.Database;
using WikiZeldaSS.ViewModels;
using WikiZeldaSS.Pages;

namespace WikiZeldaSS
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
                });

            builder.Services.AddSingleton<AppShell>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<LieuxPage>();

            builder.Services.AddSingleton<DatabaseService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }

    }

}
