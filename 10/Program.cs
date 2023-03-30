using System.Net.Http.Json;

namespace _10
{
    internal class Program
    {
        static HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            string url = "https://dev.virtualearth.net/REST/v1/LocationRecog/45.71,9.24?radius=0.5&top=15&datetime=2022-02-22%2018:50:42Z&distanceunit=km&verboseplacenames=true&includeEntityTypes=businessAndPOI,naturalPOI,address&includeNeighborhood=1&include=ciso2&key=AiNZqJ3NSiJFVQSzvkaZT_ARutQbhczJpzwdFRNuUzXKDt-2bQadX4dXLlnw9TKy";
            //inizio richiesta
            var response = await client.GetAsync(url);
            //fine richiesta
            if (!response.IsSuccessStatusCode)
            {
                return;
            }

            var result = await response.Content.ReadFromJsonAsync<BingMap>();

            for (int i = 0; i < result.ResourceSets[0].Resources[0].BusinessesAtLocation.Count; i++)
            {
                Console.WriteLine(result.ResourceSets[0].Resources[0].BusinessesAtLocation[i].BusinessAddress.FormattedAddress);
            }

        }
    }
}