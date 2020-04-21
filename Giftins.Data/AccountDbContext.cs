using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Giftins.Core.Configuration;
using Giftins.Core.Domain.User;

namespace Giftins.Data
{
    using Mapping;
    using Mapping.Account;

    public class AccountDbContext : IdentityDbContext<GiftinsUser, GiftinsRole, string>
    {
        private readonly GiftinsConfig _gconfig;

        public AccountDbContext(DbContextOptions<AccountDbContext> options, GiftinsConfig gconfig)
            : base(options)
        {
            _gconfig = gconfig;
        }

        public DbSet<UserProfile> UserProfiles { get; protected set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Map<GiftinsRole>(_gconfig);
            builder.Map<GiftinsUser>(_gconfig);
            builder.Map<IdentityUserClaim<string>>(_gconfig);
            builder.Map<IdentityRoleClaim<string>>(_gconfig);
            builder.Map<IdentityUserLogin<string>>(_gconfig);
            builder.Map<IdentityUserRole<string>>(_gconfig);
            builder.Map<IdentityUserToken<string>>(_gconfig);

            builder.Map<UserProfile>(_gconfig);
        }
    }
}
