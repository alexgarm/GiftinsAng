using Microsoft.EntityFrameworkCore;

using Giftins.Core.Configuration;
using Giftins.Core.Domain.Market;

namespace Giftins.Data
{
    using Mapping;
    using Mapping.Market;

    public class MarketDbContext : DbContext
    {
        private readonly GiftinsConfig _gconfig;

        public DbSet<Vendor> Vendors { get; protected set; }

        public DbSet<MarketCategory> Categories { get; protected set; }
        public DbSet<Marketplace> Marketplaces { get; protected set; }

        public DbSet<MarketProductCategory> ProductCategories { get; protected set; }
        public DbSet<MarketProduct> Products { get; protected set; }

        public MarketDbContext(DbContextOptions<MarketDbContext> options, GiftinsConfig gconfig)
            : base(options)
        {
            _gconfig = gconfig;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Map<Vendor>(_gconfig);
            builder.Map<Marketplace>(_gconfig);
        }
    }
}
