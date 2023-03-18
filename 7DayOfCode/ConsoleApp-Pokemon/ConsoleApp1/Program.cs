// See https://aka.ms/new-console-template for more information

using RestSharp;
using System.Text.Json;


const string URL_API = "https://pokeapi.co/api/v2/pokemon/";
var client = new RestClient(URL_API);
var request = new RestRequest("", Method.Get);
var response = client.Execute(request);

if(response.StatusCode == System.Net.HttpStatusCode.OK)
{
   Console.WriteLine(response.Content);
    
}
else
{
    Console.WriteLine(response.ErrorMessage);
}    

Console.ReadKey();

public class Pokemon
{
    public string Name { get; set; }
    public string URL { get; set; }
}




