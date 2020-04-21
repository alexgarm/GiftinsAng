using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Giftins.Core.Domain.Market;
using Giftins.Core.Configuration;

namespace Giftins.Data.Mapping.Market
{
    public class VendorMap : EntityTypeConfiguration<Vendor>
    {
        public override string TableName => "Vendors";

        public VendorMap(GiftinsConfig gconfig)
            : base(gconfig)
        { }

        protected override void MapEntity(EntityTypeBuilder<Vendor> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.UserId)
                .HasMaxLength(36)
                .ValueGeneratedNever()
                .IsRequired();

            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .IsRequired();

            entity.HasIndex(e => e.UserId);
        }
    }

    public static class VendorMapExtension
    {
        public static void MapGiftinsVendor<T>(this ModelBuilder builder, GiftinsConfig gconfig)
            where T: Vendor
        {
            new VendorMap(gconfig).OnModelCreating(builder);
        }
    }
}
