// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources => 
            new IdentityResource[] 
            {
                new IdentityResources.OpenId(), 
                new IdentityResources.Profile(), 
                new IdentityResource("roles", new List<string> { "role" })
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("scope1"),
                new ApiScope("scope2"),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
               new Client()
                {
                    RedirectUris = new List<string>
                    {
                        "https://localhost:44332/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:44332/signout-callback-oidc"
                    },                    
                    FrontChannelLogoutUri = "https://localhost:44332/signout-oidc",
                    ClientId = "ImpersonationClient",
                    ClientName = "ImpersonationClient",
                    AllowedGrantTypes = GrantTypes.Code,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles"
                    },
                    ClientSecrets = new List<Secret> { new Secret("secret".Sha256()) },
                    AllowOfflineAccess = true,
                    RequireConsent = false
                }
            };
    }
}