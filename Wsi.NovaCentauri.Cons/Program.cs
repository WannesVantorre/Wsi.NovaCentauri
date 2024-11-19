using Involved.HTF.Common;

namespace Wsi.NovaCentauri.Cons
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            HackTheFutureClient client = new HackTheFutureClient();
            await client.Login(Constants.Name, Constants.Token);
        }
    }
}
