using Involved.HTF.Common;
using System.Net.Http.Json;
using Wsi.NovaCentauri.Cons.Models;

namespace Wsi.NovaCentauri.Cons
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            HackTheFutureClient client = new();
            await client.Login(Constants.Name, Constants.Token);
            string url = "https://app-htf-2024.azurewebsites.net/api/a/medium/sample";
            Game game = await client.GetFromJsonAsync<Game>(url) ?? throw new InvalidDataException();
            Console.WriteLine(game);
        }
    }
}
