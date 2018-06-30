using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Tutorial.AspNetSecurity.TokenService
{
    public class Config
    {
        /// <summary>
        /// Identity resources allowed
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                // Custom resource
                new IdentityResource
                {
                    Name = "Role",
                    UserClaims = new List<string> { "Role" }
                }
            };
        }

        /// <summary>
        /// Clients allowed
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "RouxAcademyMVC",
                    ClientName = "Roux Academy MVC Client",
                    // how the clients interact with the IdentityServer
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris = { "http://localhost:5002/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email
                    }
                }
            };
        }
    }
}
