using Muscles_app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Muscles_app.Services
{
    public class ExerciseTypeManager
    {
        public static async Task<ExerciseType> ReadAsync(int key, bool useNavigationalProperties = false)
        {
            try
            {
                var response = await Client._httpClient.GetAsync(Client._url + $"ExerciseType/{key}?useNavigationalProperties={useNavigationalProperties}");
                ExerciseType workout = JsonConvert.DeserializeObject<ExerciseType>(await response.Content.ReadAsStringAsync());
                return workout;
            }
            catch (HttpRequestException e)
            {

                Console.WriteLine($"Request error: {e.Message}");
                return null;
            }
        }

        public static async Task CreateAsync(ExerciseType item)
        {
            try
            {
                var json = JsonConvert.SerializeObject(item);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await Client._httpClient.PostAsync(Client._url + $"ExerciseType", data);
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
                var response = await Client._httpClient.DeleteAsync(Client._url + $"ExerciseType/{key}");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }
        }
        public static async Task<ICollection<ExerciseType>> ReadAllAsync(bool useNavigationalProperties = false)
        {

            try
            {
                var response = await Client._httpClient.GetAsync(Client._url + $"ExerciseType?useNavigationalProperties={useNavigationalProperties}");
                List<ExerciseType> workout = JsonConvert.DeserializeObject<List<ExerciseType>>(await response.Content.ReadAsStringAsync());
                return workout;
            }
            catch (HttpRequestException e)
            {

                Console.WriteLine($"Request error: {e.Message}");
                return null;
            }
        }
        public static async Task UpdateAsync(ExerciseType item, bool useNavigationalProperties = false)
        {
            try
            {
                var json = JsonConvert.SerializeObject(item);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await Client._httpClient.PutAsync(Client._url + $"ExerciseType/{item.ExerciseTypeId}?useNavigationalProperties={useNavigationalProperties}", data);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }

        }
    }
}
