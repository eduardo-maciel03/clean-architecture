using AppMaui.Views;
using AppUseCases.ServicesInterfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppMaui.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly IViewUsersUseCases _viewUsersUseCases;

        [ObservableProperty]
        string username;

        [ObservableProperty]
        bool rememberMe;

        public LoginViewModel(IViewUsersUseCases viewUsersUseCases)
        {
            _viewUsersUseCases = viewUsersUseCases;
        }

        [RelayCommand]
        public async Task Login()
        {
            var users = await _viewUsersUseCases.ExecuteAsyncFilter();

            if (string.IsNullOrWhiteSpace(Username))
            {
                await App.Current.MainPage.DisplayAlert("Aviso", "Campo nome não preenchido!", "OK");
                return;
            }

            await UserPreferences();

            foreach (var user in users)
            {
                if(string.Equals(Username, user.Name, StringComparison.OrdinalIgnoreCase))
                {
                    await Shell.Current.GoToAsync($"//{nameof(HomeView)}");
                    return;
                }
            }
            
            await App.Current.MainPage.DisplayAlert("Aviso", "Usuário não existe!", "OK");
        }

        private async Task UserPreferences()
        {
            if (RememberMe)
            {
                Preferences.Default.Set(Constants.RememberMe, RememberMe);

                await SecureStorage.Default.SetAsync(Constants.Username, Username);
            }
        }

    }
}
