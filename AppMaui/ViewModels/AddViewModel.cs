using AppCore.Models;
using AppMaui.Views;
using AppUseCases.ServicesInterfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppMaui.ViewModels
{
    public partial class AddViewModel : ObservableObject
    {
        private readonly IViewUsersUseCases _viewUsersUseCases;

        [ObservableProperty]
        string username;
        [ObservableProperty]
        string phone;

        public AddViewModel(IViewUsersUseCases viewUsersUseCases)
        {
            _viewUsersUseCases = viewUsersUseCases;
        }

        [RelayCommand]
        public async Task Save()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Phone))
            {
                await App.Current.MainPage.DisplayAlert("Aviso", "Campos não preenchidos", "OK");
                return;
            }

            var newUser = new Users() 
            {
                Name = Username,
                Phone = Phone
            };

            var users = await _viewUsersUseCases.ExecuteAsyncFilter();

            foreach(var user in users)
            {
                if(newUser.Name == user.Name)
                {
                    await App.Current.MainPage.DisplayAlert("Aviso", "Usuário já existe", "OK");
                    return;
                }
            }

            await _viewUsersUseCases.ExecuteAsyncAdd(newUser);
            await Shell.Current.GoToAsync($"//{nameof(UsersView)}");
            Username = null;
            Phone = null;
        }

        [RelayCommand]
        public async Task GoBack()
        {
            await Shell.Current.GoToAsync($"//{nameof(UsersView)}");
        }
    }
}
