using Involved.HTF.Common;
using System.Net.Http.Json;
using System.Text.Json;
using Wsi.NovaCentauri.Cons.Models;
using Wsi.NovaCentauri.Cons.Services;

namespace Wsi.NovaCentauri.Cons
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            HackTheFutureClient client = new();
            await client.Login(Constants.Name, Constants.Token);
            string startUrl = "https://app-htf-2024.azurewebsites.net/api/a/medium/start";
            HttpResponseMessage startResponse = await client.GetAsync(startUrl);
            await Run(client);
        }

        public static async Task Run(HackTheFutureClient client)
        {
            string getUrl = "https://app-htf-2024.azurewebsites.net/api/a/medium/puzzle";
            Game game = await client.GetFromJsonAsync<Game>(getUrl) ?? throw new InvalidDataException();

            BattleService battleService = new();
            GameResult gameResult = battleService.Run(game);

            string postUrl = "https://app-htf-2024.azurewebsites.net/api/a/medium/puzzle";
            HttpResponseMessage httpResponseMessage = await client.PostAsJsonAsync(postUrl, gameResult);
            Console.WriteLine(httpResponseMessage.StatusCode);
        }
    }
}
