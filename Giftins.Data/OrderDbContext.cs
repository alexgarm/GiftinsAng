using Microsoft.EntityFrameworkCore;

using Giftins.Core.Configuration;

namespace Giftins.Data
{
    public class OrderDbContext : DbContext
    {
        private readonly GiftinsConfig _gconfig;

        public OrderDbContext(DbContextOptions<OrderDbContext> options, GiftinsConfig gconfig)
            : base(options)
        {
            _gconfig = gconfig;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
