using System.Net.Sockets;
using System.Text.Json.Serialization;

namespace usuariosApi
{
    public class Usuarios
    {
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("username")]
        public string username { get; set; }

        [JsonPropertyName("email")]
        public string email { get; set; }

        [JsonPropertyName("address")]
        public Address address { get; set; }

        [JsonPropertyName("phone")]
        public string phone { get; set; }

        [JsonPropertyName("website")]
        public string website { get; set; }

        [JsonPropertyName("company")]
        public Company company { get; set; }
    }

    public class Address
    {
        [JsonPropertyName("street")]
        public string street { get; set; }

        [JsonPropertyName("suite")]
        public string suite { get; set; }

        [JsonPropertyName("city")]
        public string city { get; set; }

        [JsonPropertyName("zipcode")]
        public string zipcode { get; set; }

        [JsonPropertyName("geo")]
        public Geo geo { get; set; }

        public void DireccionCompleta()
        {
            Console.WriteLine($"Dirección completa: {street} {suite}, {city}, {zipcode}");
        }
    }

    public class Geo
    {
        [JsonPropertyName("lat")]
        public string lat { get; set; }

        [JsonPropertyName("lng")]
        public string lng { get; set; }
    }

    public class Company
    {
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("catchPhrase")]
        public string catchPhrase { get; set; }

        [JsonPropertyName("bs")]
        public string bs { get; set; }
    }
}