using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Giftins.Core.Configuration;
using Giftins.Core.Domain.Market;

namespace Giftins.Data.Mapping.Market
{
    public class MarketplaceMap : EntityTypeConfiguration<Marketplace>
    {
        public override string TableName => "Markets";

        public MarketplaceMap(GiftinsConfig gconfig)
            : base(gconfig)
        { }

        protected override void MapEntity(EntityTypeBuilder<Marketplace> entity)
        {
            entity.HasKey(e => e.VendorId);
            entity.Property(e => e.VendorId)
                .HasMaxLength(36)
                .ValueGeneratedNever();

            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .IsRequired();

            entity.Property(e => e.PictureId)
                .HasMaxLength(36)
                .IsRequired();

            entity.Property(e => e.Deactivated)
                .IsRequired();
        }
    }

    public static class MarketplaceMapExtension
    {
        public static void MapGiftinsMarketplace<T>(this ModelBuilder builder, GiftinsConfig gconfig)
            where T: Marketplace
        {
            new MarketplaceMap(gconfig).OnModelCreating(builder);
        }
    }
}
