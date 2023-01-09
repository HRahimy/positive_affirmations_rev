using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace WebStack.Infrastructure.Identity;
public static class IdentityConfiguration
{
    public static IEnumerable<ApiResource> GetApiResources() =>
        new List<ApiResource>
        {
            new ApiResource("Todos")
        };
    public static IEnumerable<ApiScope> GetApiScopes() =>
        new List<ApiScope>
        {
            new ApiScope("read:todos")
        };
    public static IEnumerable<Client> GetClients() =>
        new List<Client>
        {
            new Client
            {
                ClientId = "flutter",
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = true,
                AllowOfflineAccess = true,
                RequireClientSecret = false,

                RedirectUris = { "com.affirmer.app://callback" },
                PostLogoutRedirectUris = { "com.affirmer.app://callback" },

                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.OfflineAccess,
                    "read:todos"
                },
            }
        };
}
