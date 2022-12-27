using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace WebStack.Infrastructure.Identity;
public static class IdentityConfiguration
{
    public static IEnumerable<ApiResource> GetApiResources() =>
        new List<ApiResource>
        {
            new ApiResource("TodoApi")
        };
    public static IEnumerable<Client> GetClients() =>
        new List<Client>
        {
            new Client
            {
                ClientId = "flutter",
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = true,
                RequireClientSecret = false,

                RedirectUris = {"http://localhost:4000/"},
                AllowedCorsOrigins = {"http://localhost:4000"},

                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    "TodoApi"
                },

                AllowAccessTokensViaBrowser = true,
                RequireConsent = false
            }
        };
}
