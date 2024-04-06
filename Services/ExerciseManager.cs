using Muscles_app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Muscles_app.Services
{
    public class ExerciseManager
    {
        public static async Task<Exercise> ReadAsync(int key, bool useNavigationalProperties = false)
        {
            try
            {
                var response = await Client._httpClient.GetAsync(Client._url + $"Exercise/{key}?useNavigationalProperties={useNavigationalProperties}");
                Exercise workout = JsonConvert.DeserializeObject<Exercise>(await response.Content.ReadAsStringAsync());
                return workout;
            }
            catch (HttpRequestException e)
            {

                Console.WriteLine($"Request error: {e.Message}");
                return null;
            }
        }

        public static async Task CreateAsync(Exercise item)
        {
            try
            {
                var json = JsonConvert.SerializeObject(item);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await Client._httpClient.PostAsync(Client._url + $"Exercise", data);
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
                var response = await Client._httpClient.DeleteAsync(Client._url + $"Exercise/{key}");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }
        }
        public static async Task<ICollection<Exercise>> ReadAllAsync(bool useNavigationalProperties = false)
        {

            try
            {
                var response = await Client._httpClient.GetAsync(Client._url + $"Exercise?useNavigationalProperties={useNavigationalProperties}");
                List<Exercise> workout = JsonConvert.DeserializeObject<List<Exercise>>(await response.Content.ReadAsStringAsync());
                return workout;
            }
            catch (HttpRequestException e)
            {

                Console.WriteLine($"Request error: {e.Message}");
                return null;
            }
        }
        public static async Task UpdateAsync(Exercise item, bool useNavigationalProperties = false)
        {
            try
            {
                var json = JsonConvert.SerializeObject(item);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await Client._httpClient.PutAsync(Client._url + $"Exercise/{item.ExerciseId}?useNavigationalProperties={useNavigationalProperties}", data);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }

        }
    }
}
