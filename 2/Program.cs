using System.Net.Http.Json;

namespace _2
{
    public class Program
    {
        static HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            string path = "https://dev.virtualearth.net/REST/v1/Routes?wp.1=Via%20Roma%70,%20Bernareggio&wp.2=Via%20Michelangelo%20Buonarroti%207,%20Costa%20Masnaga&optimize=time&tt=departure&dt=2022-02-22%2019:35:00&distanceUnit=km&c=it&ra=regionTravelSummary&key=AjXlxdYckw9ubfg8tAwDXapDVkvPDKFlkjIu1CzTEu4czUAU-4YyC-ovIeH6dSVc";
            var response = await client.GetAsync(path);
            if (!response.IsSuccessStatusCode)
            {
                return;
            }
            BingMap ritorno = await response.Content.ReadFromJsonAsync<BingMap>();
            string text = "";
            for (int i = 0; i < ritorno.ResourceSets[0].Resources[0].RouteLegs[0].ItineraryItems.Count; i++)
            {
                text = ritorno.ResourceSets[0].Resources[0].RouteLegs[0].ItineraryItems[i].Instruction.Text;
                Console.WriteLine(text);
            }
        }
    }
}