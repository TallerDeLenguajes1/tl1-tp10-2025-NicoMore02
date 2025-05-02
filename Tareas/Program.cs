// See https://aka.ms/new-console-template for more information
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using clases;
using System.Dynamic;
class program {
    private static readonly HttpClient client = new HttpClient();
    //private const string url = "https://jsonplaceholder.typicode.com/todos/";

    static async Task Main(string[] args) 
    {
        var tareas = await GetTareas();
        mostrarTareas(tareas);
        
    }

    static async Task<List<Tarea>> GetTareas() 
    {
        HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/todos/");
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        List<Tarea> listtareas = JsonSerializer.Deserialize<List<Tarea>>(responseBody);
        return listtareas;
    }

    static void mostrarTareas(List<Tarea> tareas) 
    {
        Console.WriteLine("====Tareas====");
        foreach (var tarea in tareas)
        {
            Console.WriteLine($"Id: {tarea.id}, Titulo: {tarea.tittle}");
        }
    }
}
