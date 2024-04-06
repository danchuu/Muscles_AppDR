using Muscles_app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Muscles_app.Services
{
    public static class WorkoutManager
    {
        public static async Task<Workout> ReadAsync(int key, bool useNavigationalProperties = false)
        {
            try
            {
                var response = await Client._httpClient.GetAsync(Client._url + $"Workout/{key}?useNavigationalProperties={useNavigationalProperties}");
                Workout workout = JsonConvert.DeserializeObject<Workout>(await response.Content.ReadAsStringAsync());
                return workout;
            }
            catch (HttpRequestException e)
            {

                Console.WriteLine($"Request error: {e.Message}");
                return null;
            }
        }

        public static async Task CreateAsync(Workout item)
        {
            try
            {
                var json = JsonConvert.SerializeObject(item);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await Client._httpClient.PostAsync(Client._url + $"Workout", data);
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
                var response = await Client._httpClient.DeleteAsync(Client._url + $"Workout/{key}");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }
        }
        public static async Task<ICollection<Workout>> ReadAllAsync(bool useNavigationalProperties = false)
        {


            try
            {
                var response = await Client._httpClient.GetAsync(Client._url + $"Workout?useNavigationalProperties={useNavigationalProperties}");
                List<Workout> workout = JsonConvert.DeserializeObject<List<Workout>>(await response.Content.ReadAsStringAsync());

                return workout;

            }
            catch (HttpRequestException e)
            {

                Console.WriteLine($"Request error: {e.Message}");
                return null;
            }
        }
        public static async Task UpdateAsync(Workout item, bool useNavigationalProperties = false)
        {
                try
                {
                    var json = JsonConvert.SerializeObject(item);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await Client._httpClient.PutAsync(Client._url + $"Workout/{item.WorkoutId}?useNavigationalProperties={useNavigationalProperties}", data);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request error: {e.Message}");
                }
            
        }
    }
}
