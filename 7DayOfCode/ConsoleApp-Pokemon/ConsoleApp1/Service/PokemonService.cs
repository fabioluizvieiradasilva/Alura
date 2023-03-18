using ConsoleApp1.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp1.Service
{
    public class PokemonService
    {
        const string URL_API = "https://pokeapi.co/api/v2/pokemon/";


        public static Mascote BuscarTodos()
        {
            var client = new RestClient(URL_API);
            var request = new RestRequest(URL_API, Method.Get);
            var response = client.Execute(request);
            
            Mascote mascote = new Mascote();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                mascote = JsonSerializer.Deserialize<Mascote>(response.Content);
            }
            else
            {
                Console.WriteLine("Erro!");
            }

            return mascote;
        }
        public static Mascote BuscarMascotePorId(string id)
        {
            var client = new RestClient(URL_API + id);
            var request = new RestRequest(URL_API + id, Method.Get);
            var response = client.Execute(request);

            Mascote mascote = new Mascote();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                mascote = JsonSerializer.Deserialize<Mascote>(response.Content);
            }
            else
            {
                Console.WriteLine("Erro!");
            }

            return mascote;
        }
    }
}
