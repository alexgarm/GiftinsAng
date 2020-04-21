using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;

using Giftins.Data;
using Giftins.Core.Domain.User;

namespace Giftins.Data.UserContext.Initializing
{
    public static class RolesInitializing
    {
        public static void SeedRoles(this RoleManager<GiftinsRole> roleManager)
        {
            List<string> roles = new List<string>()
            {
                GiftinsRole.ROOT
            };

            foreach (var roleName in roles)
            {
                if (!roleManager.RoleExistsAsync(roleName).Result)
                {
                    GiftinsRole role = new GiftinsRole(roleName);
                    var res = roleManager.CreateAsync(role).Result;

                    if (!res.Succeeded)
                        throw new ApplicationException($"Unable to create {roleName} role. {string.Join(",", res.Errors.Select(e => e.Description))}");
                }
            }
        }
    }
}
