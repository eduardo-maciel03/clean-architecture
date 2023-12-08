using AppCore.Models;
using AppUseCases.PluginInterfaces;
using System.Text;
using System.Text.Json;

namespace Plugins.DataStore.API.PluginRepository
{
    public class UserRepository : IUserRepository
    {
        private HttpClient _client;
        private JsonSerializerOptions _serializerOptions;
        List<Users> users;

        public UserRepository()
        {
            users = new List<Users>();
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }

        public async Task<List<Users>> GetUsers(string filterText = null)
        {
            Uri uri;

            try
            {
                if (string.IsNullOrWhiteSpace(filterText))
                    uri = new Uri($"{Constants.WebApiBaseUrl}users");
                else
                    uri = new Uri($"{Constants.WebApiBaseUrl}name?s={filterText}");

                using (HttpResponseMessage response = await _client.GetAsync(uri))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        users = JsonSerializer.Deserialize<List<Users>>(content, _serializerOptions);
                    }
                }

                return users;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Users>> GetUser(int id)
        {
            Uri uri = new Uri($"{Constants.WebApiBaseUrl}user/{id}");

            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    users = JsonSerializer.Deserialize<List<Users>>(content, _serializerOptions);
                }

                return users;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task AddUser(Users user)
        {
            try
            {
                string json = JsonSerializer.Serialize<Users>(user, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                Uri uri = new Uri($"{Constants.WebApiBaseUrl}post");
                await _client.PostAsync(uri, content);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateUser(int id, Users user)
        {
            try
            {
                string json = JsonSerializer.Serialize<Users>(user, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                Uri uri = new Uri($"{Constants.WebApiBaseUrl}update/{id}");
                await _client.PutAsync(uri, content);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteUser(int id)
        {
            try
            {
                Uri uri = new Uri($"{Constants.WebApiBaseUrl}delete/{id}");
                await _client.DeleteAsync(uri);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
