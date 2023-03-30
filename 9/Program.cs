using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;

namespace _9
{
    internal class Program
    {
        static HttpClient client;
        static async Task Main(string[] args)
        {
            client = new HttpClient();
            string path = "https://api.open-meteo.com/v1/forecast?latitude=45.71&longitude=9.25&hourly=temperature_2m&daily=temperature_2m_max,temperature_2m_min&timezone=Europe%2FBerlin";
            var response = await client.GetAsync(path);

            if (!response.IsSuccessStatusCode)
            {
                return;
            }

            var result = await response.Content.ReadFromJsonAsync<WeatherMap>();
            List<Double> tempMin = new List<double>(); 
            for (int i = 0; i < result.Daily.Temperature2mMin.Count; i++)
            {
                tempMin.Add(result.Daily.Temperature2mMin[i]);  
            }
            foreach (var item in tempMin)
            {
                Console.WriteLine(item);
            }
        }
    }
}