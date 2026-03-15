using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ConsumerPokeApi.Models;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Digite o nome do Pokémon:");
        string nomePokemon = Console.ReadLine()?.ToLower();

        if (string.IsNullOrWhiteSpace(nomePokemon))
        {
            Console.WriteLine("Nome inválido!");
            return;
        }

        string url = $"https://pokeapi.co/api/v2/pokemon/{nomePokemon}";

        using HttpClient client = new HttpClient();

        try
        {
            Pokemon pokemon = await client.GetFromJsonAsync<Pokemon>(url);

            if (pokemon != null)
            {
                Console.WriteLine($"ID: {pokemon.Id}");
                Console.WriteLine($"Nome: {pokemon.Name}");
                Console.WriteLine($"Altura: {pokemon.Height}");
                Console.WriteLine($"Peso: {pokemon.Weight}");
            }
            else
            {
                Console.WriteLine("Pokémon não encontrado!");
            }
        }
        catch (HttpRequestException)
        {
            Console.WriteLine("Erro ao acessar a API");
        }
    }
}