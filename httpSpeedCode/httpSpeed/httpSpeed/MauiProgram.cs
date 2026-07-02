using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Views;
using httpSpeed.View;
using httpSpeed.ViewModel;
using Microsoft.Extensions.Logging;

namespace httpSpeed
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddTransientPopup<NamePopup, NamePopupViewModel>();
            builder.Services.AddTransient<MauiMainPage, MauiMainPageViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
