using System.Diagnostics;
using System.Linq.Expressions;
using System.Net.Http.Json;

namespace _7
{
    internal class Program
    {
        static HttpClient client;

        static async Task Main(string[] args)
        {
            client = new HttpClient();
            string path = "https://www.inps.it/it/it.html";
            Stopwatch crono = new Stopwatch();
            crono.Start();
            var response = await client.GetAsync(path);
            crono.Stop();
            if (!response.IsSuccessStatusCode)
            {
                return;
            }
            var result = await response.Content.ReadAsByteArrayAsync();
            Console.WriteLine($"il tempo è di: {crono.ElapsedMilliseconds} e pesa: {result.Length}");
            var html = await response.Content.ReadAsStreamAsync();
            var stream = File.Create("./HTML/html.html");
            html.CopyTo(stream);
        }
    }
}