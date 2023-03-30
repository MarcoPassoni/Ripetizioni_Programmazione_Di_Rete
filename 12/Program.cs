namespace _12
{
    internal class Program
    {
        static HttpClient client= new HttpClient();

        static async Task Main(string[] args)
        {
            string path = "https://www.ilgiorno.it/";
            var response = await client.GetAsync(path);
            if (!response.IsSuccessStatusCode)
            {
                return;
            }
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
            File.WriteAllText("./file.html", result);
        }
    }
}