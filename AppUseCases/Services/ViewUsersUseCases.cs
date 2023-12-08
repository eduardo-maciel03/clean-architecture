using AppCore.Models;
using AppUseCases.PluginInterfaces;
using AppUseCases.ServicesInterfaces;

namespace AppUseCases.Services
{
    public class ViewUsersUseCases : IViewUsersUseCases
    {
        private readonly IUserRepository _userRepository;
        public ViewUsersUseCases(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<Users>> ExecuteAsyncFilter(string filterText = null)
        {
            return await _userRepository.GetUsers(filterText);            
        }

        public async Task<List<Users>> ExecuteAsyncId(int id)
        {
            return await _userRepository.GetUser(id);
        }

        public async Task ExecuteAsyncAdd(Users user)
        {
            await _userRepository.AddUser(user);
        }

        public async Task ExecuteAsyncUpdate(int id, Users user)
        {
            await _userRepository.UpdateUser(id, user);
        }

        public async Task ExecuteAsyncDelete(int id)
        {
            await _userRepository.DeleteUser(id);
        }
    }
}
