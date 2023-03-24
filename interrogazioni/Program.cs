using System.Net.Http.Json;

namespace interrogazioni
{
    internal class Program
    {
        public static HttpClient client;

        static async Task Main(string[] args)
        {
            client = new HttpClient();
            string path = "https://jsonplaceholder.typicode.com/ps";
            var response = await client.GetAsync(path);
            if (!response.IsSuccessStatusCode)
            {
                return;
            }

            List<User>? userList = await response.Content.ReadFromJsonAsync<List<User>>();
            foreach (var item in userList)
            {
                Console.WriteLine(item.UserId);
            }
        }
    }
}