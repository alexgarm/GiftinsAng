using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Giftins.Core.Configuration;
using Giftins.Core.Domain.User;

namespace Giftins.Data
{
    using Mapping;
    using Mapping.User;

    public class UserDbContext : DbContext
    {
        private readonly GiftinsConfig _gconfig;

        public UserDbContext(DbContextOptions<UserDbContext> options, GiftinsConfig gconfig)
            : base(options)
        {
            _gconfig = gconfig;
        }

        public DbSet<FriendsRelation> FriendRelations { get; protected set; }

        public DbSet<UserSubscription> UserSubscriptions { get; protected set; }

        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Map<FriendsRelation>(_gconfig);
            builder.Map<UserSubscription>(_gconfig);
        }
    }
}
