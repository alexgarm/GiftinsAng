using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Identity;

using Giftins.Data;
using Giftins.Core.Domain.User;

namespace Giftins.Data.UserContext.Initializing
{
    public static class UsersInitializing
    {
        /// <summary>
        /// Seed user for testing
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="userManager"></param>
        /// <param name="configure"></param>
        public static void SeedUsers(this UserManager<GiftinsUser> userManager, 
            Action<UsersInitializingOptions> configureUsers)
        {
            UsersInitializingOptions config = new UsersInitializingOptions();
            List<UsersInitializingOptions> users = new List<UsersInitializingOptions>();
            configureUsers?.Invoke(config);

            var rootUsers = userManager.GetUsersInRoleAsync(config.Root.RootRole).Result;

            if (rootUsers.Count == 0)
            {
                GiftinsUser root = userManager.FindByNameAsync(config.Root.RootLogin).Result;
                if (root == null)
                {
                    root = new GiftinsUser(config.Root.RootLogin)
                    {
                        Email = config.Root.RootEmail,
                        LockoutEnabled = false
                    };

                    var profie = new UserProfile(root.Id)
                    {
                        FirstName = config.Root.RootFirstName,
                        LastName = config.Root.RootLastName,
                        Country = "",
                        City = ""
                    };
                    throw new NotImplementedException();

                    var cResult = userManager.CreateAsync(root, config.Root.RootPassword).Result;
                    if (!cResult.Succeeded)
                        throw new ApplicationException($"Unable to create root user. {string.Join(',', cResult.Errors.Select(e => e.Description))}");

                    foreach (var roleName in config.Root.RootRoles)
                    {
                        if (!userManager.IsInRoleAsync(root, roleName).Result)
                        {
                            var rResult = userManager.AddToRoleAsync(root, roleName).Result;
                            if (!rResult.Succeeded)
                                throw new ApplicationException($"Unable to add root user to {roleName} role. {string.Join(',', rResult.Errors.Select(e => e.Description))}");
                        }
                    }
                }
                else
                {
                    foreach (var roleName in config.Root.RootRoles)
                    {
                        if (!userManager.IsInRoleAsync(root, roleName).Result)
                        {
                            var rResult = userManager.AddToRoleAsync(root, roleName).Result;
                            if (!rResult.Succeeded)
                                throw new ApplicationException($"Unable to add root user to {roleName} role. {string.Join(',', rResult.Errors.Select(e => e.Description))}");
                        }
                    }
                }
            }
            else if (rootUsers.Count > 1 && !config.Root.AllowMultipleRoot)
                throw new ApplicationException("More than one root user found");

            // TODO: add users
            if (users.Any())
                throw new NotImplementedException();
        }
    }
}
