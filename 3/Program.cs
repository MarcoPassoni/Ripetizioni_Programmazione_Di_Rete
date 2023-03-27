namespace _3
{
    internal class Program
    {
        public static HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            string path = "https://www.repubblica.it/";
            var response =  await client.GetAsync(path);
            if (!response.IsSuccessStatusCode)
            {
                return;
            }
            string content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
            File.WriteAllText("./file.html", content);
        }
    }
}