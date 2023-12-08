using AppMaui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppMaui.ShellModels
{
    public partial class AppShellViewModel : ObservableObject
    {
        [RelayCommand]
        public async Task Logout()
        {
            var confirm = await App.Current.MainPage.DisplayAlert("Aviso", "Deseja sair?", "SIM", "NÃO");
            if(confirm) 
            {
                await Shell.Current.GoToAsync($"//{nameof(LoginView)}");
            }
        }
    
    }
}
