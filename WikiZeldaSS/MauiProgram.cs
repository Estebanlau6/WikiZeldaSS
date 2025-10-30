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

            // Enregistrement de toutes les pages et ViewModels
            builder.Services.AddSingleton<AppShell>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            builder.Services.AddSingleton<PersonnagesPage>();
            builder.Services.AddSingleton<PersonnagesViewModel>();

            builder.Services.AddSingleton<LieuxPage>();
            builder.Services.AddSingleton<LieuxViewModel>();

            builder.Services.AddSingleton<ObjetsPage>();
            builder.Services.AddSingleton<ObjetsViewModel>();

            builder.Services.AddSingleton<QuetesPage>();
            builder.Services.AddSingleton<QuetesViewModel>();

            builder.Services.AddSingleton<DatabaseService>();


#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}
