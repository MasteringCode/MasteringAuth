using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MasteringAuth.Shared
{
    public static class ClientCredentials
    {
        public static async Task<TokenResponse> GetAccessToken()
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:44307");
            if (disco.IsError)
            {
                throw new Exception(disco.Error);
            }
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "consoleapp",
                ClientSecret = "consoleapp-secret",
                Scope = "api"
            });
            if (tokenResponse.IsError)
            {
                throw new Exception(tokenResponse.Error);
            }
            return tokenResponse;
        }

        public static async Task<JArray> CallApi(string accessToken)
        {
            var client = new HttpClient();
            client.SetBearerToken(accessToken);
            var response = await client.GetAsync("https://localhost:44308/identity");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.StatusCode.ToString());
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                return JArray.Parse(content);
            }
        }
    }
}
