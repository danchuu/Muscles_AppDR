using Muscles_app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Muscles_app.Services
{
    public class ExerciseTypeGroupManager
    {
        public static async Task<ExerciseTypeGroup> ReadAsync(int key, bool useNavigationalProperties = false)
        {
            try
            {
                var response = await Client._httpClient.GetAsync(Client._url + $"ExerciseTypeGroup/{key}?useNavigationalProperties={useNavigationalProperties}");
                ExerciseTypeGroup exerciseTypeGroup = JsonConvert.DeserializeObject<ExerciseTypeGroup>(await response.Content.ReadAsStringAsync());
                return exerciseTypeGroup;
            }
            catch (HttpRequestException e)
            {

                Console.WriteLine($"Request error: {e.Message}");
                return null;
            }
        }

        public static async Task CreateAsync(ExerciseTypeGroup item)
        {
            try
            {
                var json = JsonConvert.SerializeObject(item);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = Task.Run(() => Client._httpClient.PostAsync(Client._url + $"ExerciseTypeGroup", data)).GetAwaiter().GetResult();
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
                var response = await Client._httpClient.DeleteAsync(Client._url + $"ExerciseTypeGroup/{key}");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }
        }
        public static async Task<ICollection<ExerciseTypeGroup>> ReadAllAsync(bool useNavigationalProperties = false)
        {

            try
            {
                var response = await Client._httpClient.GetAsync(Client._url + $"ExerciseTypeGroup?useNavigationalProperties={useNavigationalProperties}");
                List<ExerciseTypeGroup> exerciseTypeGroup = JsonConvert.DeserializeObject<List<ExerciseTypeGroup>>(await response.Content.ReadAsStringAsync());
                return exerciseTypeGroup;
            }
            catch (HttpRequestException e)
            {

                Console.WriteLine($"Request error: {e.Message}");
                return null;
            }
        }
        public static async Task UpdateAsync(ExerciseTypeGroup item, bool useNavigationalProperties = false)
        {
            try
            {
                var json = JsonConvert.SerializeObject(item);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await Client._httpClient.PutAsync(Client._url + $"ExerciseTypeGroup/{item.ExerciseTypeGroupID}?useNavigationalProperties={useNavigationalProperties}", data);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }

        }
    }
    
}
