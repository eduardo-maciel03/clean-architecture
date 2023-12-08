using AppCore.Models;

namespace AppUseCases.PluginInterfaces
{
    public interface IUserRepository
    {
        Task<List<Users>> GetUsers(string filterText = null);
        Task<List<Users>> GetUser(int id);
        Task AddUser(Users user);
        Task UpdateUser(int id, Users user);
        Task DeleteUser(int id);
    }
}
