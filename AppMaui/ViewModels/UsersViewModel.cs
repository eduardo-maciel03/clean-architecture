using AppCore.Models;
using AppMaui.Views;
using AppUseCases.ServicesInterfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AppMaui.ViewModels
{
    public partial class UsersViewModel : ObservableObject
    {
        private readonly IViewUsersUseCases _viewUsersUseCases;

        [ObservableProperty]
        ObservableCollection<Users> listUsers;

        public static int Id { get; private set; }

        public UsersViewModel(IViewUsersUseCases viewUsersUseCases)
        {
            _viewUsersUseCases = viewUsersUseCases;
            ListUsers = new ObservableCollection<Users>();
        }

        private string filterText;
        public string FilterText
        {
            get { return filterText; }
            set
            {
                filterText = value;
                LoadUsersAsync(filterText);
            }
        }

        [RelayCommand]
        public async Task LoadUsersAsync(string filterText = null)
        {
            ListUsers.Clear();
            var users = await _viewUsersUseCases.ExecuteAsyncFilter(filterText);

            if (users != null && users.Count > 0)
            {
                foreach (var user in users)
                {
                    ListUsers.Add(user);
                }
            }
        }

        [RelayCommand]
        public async Task AddUser()
        {
            await Shell.Current.GoToAsync($"//{nameof(AddView)}");
        }

        [RelayCommand]
        public async Task UpdateUser(Users user)
        {
            Id = user.Id;
            await Shell.Current.GoToAsync($"//{nameof(EditView)}");
        }

        [RelayCommand]
        public async Task DeleteUser(Users user)
        {
            var users = await _viewUsersUseCases.ExecuteAsyncId(user.Id);

            var confirm = await App.Current.MainPage.DisplayAlert("Aviso", "Deletar?", "SIM", "NÃO");

            if (confirm)
            {
                foreach (var userToDelete in users)
                {
                    await _viewUsersUseCases.ExecuteAsyncDelete(userToDelete.Id);
                    await LoadUsersAsync();
                }
            }
            
        }
    }
}
