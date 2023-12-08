using AppCore.Models;
using AppMaui.ShellModels;
using AppMaui.ViewModels;
using AppMaui.Views;
using AppUseCases.PluginInterfaces;
using AppUseCases.Services;
using AppUseCases.ServicesInterfaces;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Plugins.DataStore.API.PluginRepository;

namespace AppMaui
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            //registrando Interfaces
            builder.Services.AddSingleton<IUserRepository, UserRepository>();
            builder.Services.AddSingleton<IViewUsersUseCases, ViewUsersUseCases>();

            //registrando ViewModels
            builder.Services.AddSingleton<UsersViewModel>();
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<EditViewModel>();
            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddSingleton<AddViewModel>();
            builder.Services.AddSingleton<AppShellViewModel>();

            //registrando Views
            builder.Services.AddSingleton<UsersView>();
            builder.Services.AddSingleton<LoginView>();
            builder.Services.AddSingleton<EditView>();
            builder.Services.AddSingleton<HomeView>();
            builder.Services.AddSingleton<AddView>();

            return builder.Build();
        }
    }
}
