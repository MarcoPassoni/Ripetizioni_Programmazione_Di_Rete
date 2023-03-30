using System.Net.Http.Json;
using System.Text.Json;

namespace _11;
public class Program
{
    static HttpClient client = new HttpClient();
    static async Task Main(string[] args)
    {
        string url = "https://it.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro&explaintext&exsectionformat=plain&redirects=1&titles=ARPANET";
        var response = await client.GetAsync(url);
        if (!response.IsSuccessStatusCode)
        {
            return;
        }

        var result = await response.Content.ReadAsStreamAsync();

        using JsonDocument document = JsonDocument.Parse(result);

        JsonElement root = document.RootElement;
        JsonElement query = root.GetProperty("query");
        JsonElement pages = query.GetProperty("pages");
        //per prendere il primo elemento dentro pages, creo un enumeratore delle properties
        JsonElement.ObjectEnumerator enumerator = pages.EnumerateObject();
        //quando si crea un enumeratore su una collection, si deve farlo avanzare di una posizione per portarlo sul primo elemento della collection
        //il primo elemento corrisponde all'id della pagina all'interno dell'oggetto pages
        string text = "";
        if (enumerator.MoveNext())
        {
            //accedo all'elemento
            JsonElement targetJsonElem = enumerator.Current.Value;
            if (targetJsonElem.TryGetProperty("extract", out JsonElement extract))
            {
                text = extract.GetString() ?? string.Empty;
            }
            else
            {
                text = string.Empty;
            }
        }
        Console.WriteLine(text);
    }
}