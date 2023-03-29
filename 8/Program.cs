using System.Net.Http.Json;
using System.Text.Json;

namespace _8
{
    internal class Program
    {
        static HttpClient client;
        static async Task Main(string[] args)
        {
             //serializzare e deserializzare una lista presa da json place holder user, una volta fatto creo un nuovo user che contenga user con nome, email e città e
            //salva la lista in un file
            client = new HttpClient();
            string path = "https://jsonplaceholder.typicode.com/users";
            var response = await client.GetAsync(path);
            if (!response.IsSuccessStatusCode)
            {
                return;
            }
            var result = await response.Content.ReadFromJsonAsync<List<User>>();
            List<NewUser> users = new List<NewUser>(result.Count);

            for (int i = 0; i < result.Count; i++)
            {
                NewUser u = new NewUser(result[i].Name, result[i].Email, result[i].Address.City);
                users.Add(u);
            }

            var json = JsonSerializer.Serialize(users);
            File.WriteAllText("./json.json", json);
        }
    }
}