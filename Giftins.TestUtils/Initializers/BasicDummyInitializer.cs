using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Giftins.Core.Domain.User;
using Giftins.Data;
using Microsoft.AspNetCore.Identity;

namespace Giftins.TestUtils.Initializers
{
    public class BasicDummyInitializer
    {
        public BasicDummyInitializer()
        { }

        public void Initialize(UserManager<GiftinsUser> userManager, AccountDbContext accountDbContext, int count)
        {
            for (int i = 0; i < count; i++)
            {
                GiftinsUser user = new GiftinsUser(FormatUsername(i))
                {
                    Email = FormatEmail(i),
                    Enabled = true,
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                userManager.CreateAsync(user);

                UserProfile profile = new UserProfile(user.Id)
                {
                    FirstName = FormatFirstName(i),
                    LastName = FormatLastName(i),
                    Birthdate = FormatBirthdateTime(i)
                };
                accountDbContext.UserProfiles.Add(profile);

            }
            accountDbContext.SaveChanges();
        }

        public static string FormatUsername(int index) => $"TESTUSER{index.ToString("D3")}";
        public static string FormatEmail(int index) => $"user{index.ToString("D3")}@somemail.test";
        public static string FormatFirstName(int index) => $"NAME{index.ToString("D3")}";
        public static string FormatLastName(int index) => $"SURNAME{index.ToString("D3")}";
        public static DateTime FormatBirthdateTime(int index) => new DateTime(1991, 9, 10).AddDays(index);
    }
}
