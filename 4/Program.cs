    using System.Reflection;

namespace _4
{
    internal class Program
    {
        public static HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            string path = "https://static2-viaggi.corriereobjects.it/wp-content/uploads/2019/11/1-1.jpg?v=353239";
            var response =  client.GetAsync(path).Result;

            if (!response.IsSuccessStatusCode)
            {
                return;
            }

            var result = await response.Content.ReadAsByteArrayAsync();
            File.WriteAllBytes("./IMMAGINI/Image_1.png", result);
        }
    }
}