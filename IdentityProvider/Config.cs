using IdentityServer4.Models;
using System.Collections.Generic;

namespace MasteringAuth.IdentityProvider
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource("api", "My API")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "consoleapp",
                    ClientName = "My Console App",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("consoleapp-secret".Sha256()) },
                    AllowedScopes = { "api" }
                },
                new Client
                {
                    ClientId = "webapp",
                    ClientName = "My Web App",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("webapp-secret".Sha256()) },
                    AllowedScopes = { "api" }
                }
            };
    }
}