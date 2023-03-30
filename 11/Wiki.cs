using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _11
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class _566
    {
        [JsonPropertyName("pageid")]
        public int Pageid { get; set; }

        [JsonPropertyName("ns")]
        public int Ns { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("extract")]
        public string Extract { get; set; }
    }

    public class Pages
    {
        [JsonPropertyName("566")]
        public _566 _566 { get; set; }
    }

    public class Query
    {
        [JsonPropertyName("pages")]
        public Pages Pages { get; set; }
    }

    public class Wiki
    {
        [JsonPropertyName("batchcomplete")]
        public string Batchcomplete { get; set; }

        [JsonPropertyName("query")]
        public Query Query { get; set; }
    }


}
