// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace PathCase.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                 new ApiResource("resource_catalog"){Scopes={ "catalog_fullpermission" } },
                 new ApiResource("resource_cart"){Scopes={ "cart_fullpermission" } },
                 new ApiResource("resource_order"){Scopes={ "order_fullpermission" } },
                 new ApiResource("resource_gateway"){Scopes={ "gateway_fullpermission" } },
                 new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                       new IdentityResources.Email(),
                       new IdentityResources.OpenId(),
                       new IdentityResources.Profile(),
                       new IdentityResource(){ Name="roles",DisplayName="Roles",Description="Kullanıcı Rolleri",UserClaims=new []{"role"} }
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("catalog_fullpermission","Catalog api için full erisim"),
                new ApiScope("cart_fullpermission","Cart api için full erisim"),
                new ApiScope("order_fullpermission","Order api için full erisim"),
                new ApiScope("gateway_fullpermission","Gatewat için full erisim"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client{
                    ClientName="Asp.Net.Core.Mvc",
                    ClientId="WebMvcClient",
                    ClientSecrets={new Secret("secret".Sha256()) },
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    AllowedScopes={ "gateway_fullpermission", "catalog_fullpermission",IdentityServerConstants.LocalApi.ScopeName }
                },
                new Client{
                    ClientName="Asp.Net.Core.Mvc",
                    ClientId="WebMvcClientForUser",
                    AllowOfflineAccess=true,
                    ClientSecrets={new Secret("secret".Sha256()) },
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                    AllowedScopes={
                        "gateway_fullpermission",
                        "cart_fullpermission",
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        IdentityServerConstants.LocalApi.ScopeName,
                        "roles",
                        "order_fullpermission"
                    },
                    AccessTokenLifetime=1*60*60,
                    RefreshTokenExpiration=TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime=(int)(DateTime.Now.AddDays(60)-DateTime.Now).TotalSeconds,
                    RefreshTokenUsage=TokenUsage.ReUse
                }
            };
    }
}