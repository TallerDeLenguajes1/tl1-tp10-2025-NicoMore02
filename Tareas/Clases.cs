using System.Text.Json;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace clases
{
    public class Tarea
    {

        [JsonPropertyName("userId")]
        public int userId { get; set; }

        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("title")]
        public string title { get; set; }

        [JsonPropertyName("completed")]
        public bool completed { get; set; }

        public string obtenerEstado()
        {
            if (completed)
            {
                return "Completada";
            }
            else
            {
                return "Pendiente";
            }
        }
    }
}