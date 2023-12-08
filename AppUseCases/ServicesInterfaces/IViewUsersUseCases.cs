using AppCore.Models;

namespace AppUseCases.ServicesInterfaces
{
    public interface IViewUsersUseCases
    {
        Task<List<Users>> ExecuteAsyncFilter(string filterText = null);
        Task<List<Users>> ExecuteAsyncId(int id);
        Task ExecuteAsyncAdd(Users user);
        Task ExecuteAsyncUpdate(int id, Users user);
        Task ExecuteAsyncDelete(int id);
    }
}
