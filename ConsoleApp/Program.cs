using MasteringAuth.Shared;
using System;
using System.Threading.Tasks;

namespace MasteringAuth.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var tokenResponse = await ClientCredentials.GetAccessToken();
                Console.WriteLine(tokenResponse.Json);
                var claims = await ClientCredentials.CallApi(tokenResponse.AccessToken);
                Console.WriteLine(claims);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
