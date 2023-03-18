// See https://aka.ms/new-console-template for more information

using ConsoleApp1.Model;
using ConsoleApp1.Service;
using RestSharp;
using System.Text.Json;

Console.WriteLine(" #######                                                                   \r\n    #       ##    #    #    ##     ####    ####   #####   ####   #    #  # \r\n    #      #  #   ##  ##   #  #   #    #  #    #    #    #    #  #    #  # \r\n    #     #    #  # ## #  #    #  #       #    #    #    #       ######  # \r\n    #     ######  #    #  ######  #  ###  #    #    #    #       #    #  # \r\n    #     #    #  #    #  #    #  #    #  #    #    #    #    #  #    #  # \r\n    #     #    #  #    #  #    #   ####    ####     #     ####   #    #  # \r\n                                                                           ");
    Console.WriteLine("Qual o seu nome?");
    string nome = Console.ReadLine();

    string opcaoEscolhida;
    bool jogar = true;
    while(jogar)
    {
        Console.WriteLine($"{nome}, o que você deseja?");
        Console.WriteLine("1 - Adotar um mascote virtual");
        Console.WriteLine("2 - Ver seus mascotes");
        Console.WriteLine("3 - Sair");
        Console.Write("Escolha:");
        opcaoEscolhida = Console.ReadLine();
        Mascote mascote;
        switch (opcaoEscolhida)
        {
            case "1":
                Console.Write("Digite o número do mascote:");
                string id = Console.ReadLine();
                mascote = PokemonService.BuscarMascotePorId(id);
                Console.WriteLine($"Nome: {mascote.Name}");
                Console.WriteLine($"Altura: {mascote.Height}");
                Console.WriteLine($"Peso: {mascote.Weight}");
                Console.WriteLine("Habilidades:");
                foreach (var item in mascote.Abilities)
                {
                    Console.WriteLine(item.Ability.Name.ToUpper());
                }
                break;
            case "2":
                mascote = PokemonService.BuscarTodos();
            int contador = 1;
                foreach (var item in mascote.Pokemons)
                {
                    Console.WriteLine($"{contador++} - {item.Name}");
                }
                break;
            case "3":
                jogar = false;
                break;
        default:
            break;
        }

    }




/*const string URL_API = "https://pokeapi.co/api/v2/pokemon/1";
var client = new RestClient(URL_API);
var request = new RestRequest(URL_API, Method.Get);
var response = client.Execute(request);

if(response.StatusCode == System.Net.HttpStatusCode.OK)
{    
    var mascote = JsonSerializer.Deserialize<Mascote>(response.Content);







}
else
{
    Console.WriteLine(response.ErrorMessage);
}    */