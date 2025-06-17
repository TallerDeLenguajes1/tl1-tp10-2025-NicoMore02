// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using usuariosApi;

class program
{
    private static readonly HttpClient client = new HttpClient();
    const string url = "https://jsonplaceholder.typicode.com/users/";

    static async Task Main(string[] asrg)
    {
        var usuarios = await GetUsuarios();
        MostrarUsuarios(usuarios);
        CrearJson(usuarios);
    }

    static async Task<List<Usuarios>> GetUsuarios()
    {
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        List<Usuarios> listaUsuarios = JsonSerializer.Deserialize<List<Usuarios>>(responseBody);
        return listaUsuarios;
    }

    static void MostrarUsuarios(List<Usuarios> usuarios)
    {
        Console.WriteLine("=====Usuarios=====");
        for (int i = 0; i < Math.Min(5, usuarios.Count); i++)
        {
            var usuario = usuarios[i];
            Console.WriteLine($"Usuario numero: {i + 1}");
            Console.WriteLine($"Nombre: {usuario.name}");
            Console.WriteLine($"Correo Electronico: {usuario.email}");
            usuario.address.DireccionCompleta();
        }
    }

    static void CrearJson(List<Usuarios> usuarios)
    {
        string json = JsonSerializer.Serialize(usuarios);
        File.WriteAllText("usuarios.json", json);
    }
}