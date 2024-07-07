using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppMaui.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        [ObservableProperty]
        string? username;

        [RelayCommand]
        public async Task RefreshUsername()
        {
            Username = await SecureStorage.Default.GetAsync(Constants.Username);
        }
    }
}
