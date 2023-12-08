using AppCore.Models;
using AppMaui.Views;
using AppUseCases.ServicesInterfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppMaui.ViewModels
{
    public partial class EditViewModel : ObservableObject
    {
        private readonly IViewUsersUseCases _viewUsersUseCases;

        [ObservableProperty]
        string? username;
        [ObservableProperty]
        string? phone;

        public EditViewModel(IViewUsersUseCases viewUsersUseCases)
        {
            _viewUsersUseCases = viewUsersUseCases;
        }

        [RelayCommand]
        public async Task GetUserToUpdate()
        {
            var userToUpdate = await _viewUsersUseCases.ExecuteAsyncId(UsersViewModel.Id);

            foreach(var user in userToUpdate)
            {
                Username = user.Name;
                Phone = user.Phone;
            }
        }

        [RelayCommand]
        public async Task UpdateUser()
        {
            var users = await _viewUsersUseCases.ExecuteAsyncFilter();

            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Phone))
            {
                await App.Current.MainPage.DisplayAlert("Aviso", "Campos não preenchidos", "OK");
                return;
            }

            foreach (var user in users)
            {
                if (user.Id == UsersViewModel.Id)
                {
                    var updateUser = new Users()
                    {
                        Name = this.Username,
                        Phone = this.Phone
                    };

                    var confirm = await App.Current.MainPage.DisplayAlert("Aviso", "Alterar?", "SIM", "NÃO");
                    if (confirm)
                    {
                        await _viewUsersUseCases.ExecuteAsyncUpdate(user.Id, updateUser);
                        await Shell.Current.GoToAsync($"//{nameof(UsersView)}");
                    }
                }
            }

            Username = null;
            Phone = null;
        }

        [RelayCommand]
        public async Task Cancel()
        {
            Username = null;
            Phone = null;
            await Shell.Current.GoToAsync($"//{nameof(UsersView)}");
        }
    }
}
