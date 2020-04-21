using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Giftins.Core.Configuration;
using Giftins.Core.Domain.Basket;

namespace Giftins.Data.Mapping.User
{
    public class BasketItemMap : EntityTypeConfiguration<BasketItem>
    {
        public override string TableName => "Basket";
        
        public BasketItemMap(GiftinsConfig gconfig)
            : base(gconfig)
        { }

        protected override void MapEntity(EntityTypeBuilder<BasketItem> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasValueGenerator<GuidValueGenerator>()
                .ValueGeneratedOnAdd();

            entity.Property(e => e.Id_User)
                .HasMaxLength(36)
                .IsRequired();
            entity.Property(e => e.AddedUtc)
                .IsRequired();

            entity.Property(e => e.Quantity)
                .IsRequired();

            entity.HasIndex(e => e.Id_User);
        }
    }
}
