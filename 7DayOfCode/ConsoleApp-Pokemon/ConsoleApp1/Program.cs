// See https://aka.ms/new-console-template for more information

using ConsoleApp1.Model;
using RestSharp;
using System.Text.Json;


const string URL_API = "https://pokeapi.co/api/v2/pokemon/1";
var client = new RestClient(URL_API);
var request = new RestRequest(URL_API, Method.Get);
var response = client.Execute(request);

if(response.StatusCode == System.Net.HttpStatusCode.OK)
{
    
    var mascote = JsonSerializer.Deserialize<Mascote>(response.Content);
    Console.WriteLine($"Nome: {mascote.Name}");
    Console.WriteLine($"Altura: {mascote.Height}");
    Console.WriteLine($"Peso: {mascote.Weight}");
    Console.WriteLine("Habilidades:");
    foreach( var item in mascote.Abilities)
    {
        Console.WriteLine(item.Ability.Name.ToUpper());        
    }

}
else
{
    Console.WriteLine(response.ErrorMessage);
}    