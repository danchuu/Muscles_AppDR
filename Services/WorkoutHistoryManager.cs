using Models;
using Muscles_app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Muscles_app.Services
{
    public class WorkoutHistoryManager
    {
        public static async Task<WorkoutHistory> ReadAsync(int key, bool useNavigationalProperties = false)
        {
            try
            {
                var response = await Client._httpClient.GetAsync(Client._url + $"WorkoutHistory/{key}?useNavigationalProperties={useNavigationalProperties}");
                WorkoutHistory workoutHistory = JsonConvert.DeserializeObject<WorkoutHistory>(await response.Content.ReadAsStringAsync());
                return workoutHistory;
            }
            catch (HttpRequestException e)
            {

                Console.WriteLine($"Request error: {e.Message}");
                return null;
            }
        }

        public static async Task CreateAsync(WorkoutHistory item)
        {
            try
            {
                var json = JsonConvert.SerializeObject(item);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await Client._httpClient.PostAsync(Client._url + $"WorkoutHistory", data);
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
                var response = await Client._httpClient.DeleteAsync(Client._url + $"WorkoutHistory/{key}");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }
        }
        public static async Task<ICollection<WorkoutHistory>> ReadAllAsync(bool useNavigationalProperties = false)
        {

            try
            {
                var response = await Client._httpClient.GetAsync(Client._url + $"WorkoutHistory?useNavigationalProperties={useNavigationalProperties}");
                List<WorkoutHistory> workoutHistory = JsonConvert.DeserializeObject<List<WorkoutHistory>>(await response.Content.ReadAsStringAsync());
                return workoutHistory;
            }
            catch (HttpRequestException e)
            {

                Console.WriteLine($"Request error: {e.Message}");
                return null;
            }
        }
        public static async Task UpdateAsync(WorkoutHistory item, bool useNavigationalProperties = false)
        {
            try
            {
                var json = JsonConvert.SerializeObject(item);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await Client._httpClient.PutAsync(Client._url + $"WorkoutHistory/{item.WorkoutHistoryId}?useNavigationalProperties={useNavigationalProperties}", data);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }

        }
    }
}
