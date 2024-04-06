using Muscles_app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Muscles_app.Services
{
    public static class UserManaging
    {
        public static async Task<User> ReadAsync(int key, bool useNavigationalProperties = false)
        {
            try
            {
                var response = await Client._httpClient.GetAsync(Client._url + $"User/{key}?useNavigationalProperties={useNavigationalProperties}");
                User user = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
                return user;
            }
            catch (HttpRequestException e)
            {

                Console.WriteLine($"Request error: {e.Message}");
                return null;
            }
        }

        public static async Task CreateAsync(User item)
        {
            try
            {
                var json = JsonConvert.SerializeObject(item);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = Task.Run(() => Client._httpClient.PostAsync(Client._url + $"User", data)).GetAwaiter().GetResult();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }
        }

        public static async Task DeleteAsync(int key)
        {
            try
            {
                var response = await Client._httpClient.DeleteAsync(Client._url + $"User/{key}");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }
        }
        public static async Task<ICollection<User>> ReadAllAsync(bool useNavigationalProperties = false)
        {

            try
            {
                var response = await Client._httpClient.GetAsync(Client._url + $"User?useNavigationalProperties={useNavigationalProperties}");
                List<User> user = JsonConvert.DeserializeObject<List<User>>(await response.Content.ReadAsStringAsync());
                return user;
            }
            catch (HttpRequestException e)
            {

                Console.WriteLine($"Request error: {e.Message}");
                return null;
            }
        }
        public static async Task UpdateAsync(User item, bool useNavigationalProperties = false)
        {
            try
            {
                var json = JsonConvert.SerializeObject(item);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await Client._httpClient.PutAsync(Client._url + $"User/{item.Id}?useNavigationalProperties={useNavigationalProperties}", data);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }

        }
    }
}

