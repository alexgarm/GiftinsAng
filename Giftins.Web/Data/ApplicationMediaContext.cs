using Microsoft.EntityFrameworkCore;

using Giftins.Core.Configuration;
using Giftins.Data;

namespace Giftins.Web.Data
{
    public class ApplicationMediaContext : MediaDbContext
    {
        public ApplicationMediaContext(DbContextOptions<MediaDbContext> options, GiftinsConfig gconfig)
            : base(options, gconfig)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
