using System.Net.Http.Json;
using MwParserFromScratch;
namespace _6
{
    internal class Program
    {
        public static HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            string path = "https://it.wikipedia.org/w/api.php?action=parse&format=json&page=Giovanni_Boccaccio&prop=wikitext&section=24&disabletoc=1";
            var response = await client.GetAsync(path);

            if (!response.IsSuccessStatusCode)
            {
                return;
            }

            var result = await response.Content.ReadFromJsonAsync<WikiClass>();
            var parser = new WikitextParser();
            Console.WriteLine(parser.Parse(result.Parse.Wikitext.Text));
        }
    }
}