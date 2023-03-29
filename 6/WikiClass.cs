using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _6
{
    public class Parse
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("pageid")]
        public int Pageid { get; set; }

        [JsonPropertyName("wikitext")]
        public Wikitext Wikitext { get; set; }
    }

    public class WikiClass
    {
        [JsonPropertyName("parse")]
        public Parse Parse { get; set; }
    }

    public class Wikitext
    {
        [JsonPropertyName("*")]
        public string Text { get; set; }
    }
}
