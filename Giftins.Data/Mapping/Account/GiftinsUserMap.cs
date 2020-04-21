using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Giftins.Core.Configuration;
using Giftins.Core.Domain.User;

namespace Giftins.Data.Mapping.Account
{
    public class GiftinsUserMap : EntityTypeConfiguration<GiftinsUser>
    {
        public override string TableName => "Users";

        public GiftinsUserMap(GiftinsConfig gconfig) 
            : base(gconfig)
        { }

        protected override void MapEntity(EntityTypeBuilder<GiftinsUser> entity)
        {
            entity.Property(e => e.Id)
                .HasMaxLength(36);

            entity.Property(e => e.Enabled)
                .IsRequired();
        }
    }

    public static class GiftinsUserMapExtension
    {
        public static void MapGiftinsUsers<T>(this ModelBuilder builder, GiftinsConfig gconfig)
            where T: GiftinsUser
        {
            new GiftinsUserMap(gconfig).OnModelCreating(builder);
        }
    }
}
