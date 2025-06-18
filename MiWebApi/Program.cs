// See https://aka.ms/new-console-template for more information
//Api https://www.cheapshark.com/api/1.0/deals?upperPrice=15

using System.Reflection.Metadata;
using System.Text.Json;
using JuegosApi;

class program
{
    private static readonly HttpClient client = new HttpClient();
    private const string url = "https://www.cheapshark.com/api/1.0/deals?upperPrice=15";

    static async Task Main(string[] asrg)
    {
        var juegos = await GetJuegos();
        MostrarLista(juegos);
        crearJson(juegos);
    }



    static async Task<List<Juegos>> GetJuegos()
    {
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        List<Juegos> listaJuegos = JsonSerializer.Deserialize<List<Juegos>>(responseBody);
        return listaJuegos;
    }

    static void MostrarLista(List<Juegos> juegos)
    {
        foreach (var juego in juegos)
        {
            Console.WriteLine("Nombre: " + juego.Title);
            Console.WriteLine($"Precio con descuento: ${juego.SalePrice} || Precio original: ${juego.NormalPrice} te ahorras un: {juego.Savings}%");
            Console.WriteLine($"Rating: {juego.SteamRatingPercent}%");
        }
    }

    static void crearJson(List<Juegos> juegos)
    {
        string json = JsonSerializer.Serialize(juegos, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("juegos.json", json);
    }
}