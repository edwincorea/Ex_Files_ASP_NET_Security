using IdentityServer4.Models;
using System.Collections.Generic;

namespace Tutorial.AspNetSecurity.TokenService
{
    public class Config
    {
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
    }
}
