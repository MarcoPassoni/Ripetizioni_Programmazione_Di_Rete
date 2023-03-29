using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _8
{
    public class NewUser
    {
        public NewUser(string name, string email, string city)
        {
            Name = name;
            Email = email;
            City = city;
        }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }
    }
}
