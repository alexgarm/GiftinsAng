using Microsoft.EntityFrameworkCore;

using Giftins.Core.Configuration;
using Giftins.Core.Domain.Media;

namespace Giftins.Data
{
    using Mapping;
    using Mapping.Media;

    public class MediaDbContext : DbContext
    {
        private readonly GiftinsConfig _gconfig;

        public MediaDbContext(DbContextOptions<MediaDbContext> options, GiftinsConfig gconfig)
            : base(options)
        {
            _gconfig = gconfig;
        }

        public DbSet<Picture> Pictures { get; protected set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Map<Picture>(_gconfig);
        }
    }
}
