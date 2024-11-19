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
            //Test(client);
        }

        public static async Task Run(HackTheFutureClient client)
        {
            string getUrl = "https://app-htf-2024.azurewebsites.net/api/a/medium/sample";
            Game game = await client.GetFromJsonAsync<Game>(getUrl) ?? throw new InvalidDataException();

            BattleService battleService = new();
            GameResult gameResult = battleService.Run(game);

            string postUrl = "https://app-htf-2024.azurewebsites.net/api/a/medium/sample";
            HttpResponseMessage httpResponseMessage = await client.PostAsJsonAsync(postUrl, gameResult);
            Console.WriteLine(httpResponseMessage.StatusCode);
        }

        public static void Test(HackTheFutureClient client)
        {
            string input = "{\r\n  \"teamA\": [\r\n    {\r\n      \"strength\": 8,\r\n      \"speed\": 50,\r\n      \"health\": 96\r\n    },\r\n    {\r\n      \"strength\": 49,\r\n      \"speed\": 93,\r\n      \"health\": 114\r\n    },\r\n    {\r\n      \"strength\": 51,\r\n      \"speed\": 7,\r\n      \"health\": 63\r\n    },\r\n    {\r\n      \"strength\": 31,\r\n      \"speed\": 79,\r\n      \"health\": 149\r\n    },\r\n    {\r\n      \"strength\": 42,\r\n      \"speed\": 76,\r\n      \"health\": 89\r\n    }\r\n  ],\r\n  \"teamB\": [\r\n    {\r\n      \"strength\": 25,\r\n      \"speed\": 78,\r\n      \"health\": 113\r\n    },\r\n    {\r\n      \"strength\": 45,\r\n      \"speed\": 92,\r\n      \"health\": 104\r\n    },\r\n    {\r\n      \"strength\": 61,\r\n      \"speed\": 65,\r\n      \"health\": 56\r\n    },\r\n    {\r\n      \"strength\": 69,\r\n      \"speed\": 142,\r\n      \"health\": 15\r\n    },\r\n    {\r\n      \"strength\": 14,\r\n      \"speed\": 39,\r\n      \"health\": 68\r\n    }\r\n  ]\r\n}";
            Game game = JsonSerializer.Deserialize<Game>(input) ?? throw new InvalidDataException();

            BattleService battleService = new();
            GameResult gameResult = battleService.Run(game);

            string serialisedGameResult = JsonSerializer.Serialize(gameResult) ?? throw new InvalidDataException();
            Console.WriteLine(serialisedGameResult);
        }
    }
}
