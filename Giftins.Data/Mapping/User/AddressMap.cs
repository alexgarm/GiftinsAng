using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Giftins.Core.Domain.User;
using Giftins.Core.Configuration;

namespace Giftins.Data.Mapping.User
{
    public class AddressMap : EntityTypeConfiguration<UserAddress>
    {
        public override string TableName => "Addresses";

        public AddressMap(GiftinsConfig gconfig)
            : base(gconfig)
        {
        }

        protected override void MapEntity(EntityTypeBuilder<UserAddress> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.CountryCode).IsRequired();
            entity.Property(e => e.StateProvinceId).IsRequired();

            entity.Property(e => e.City).HasMaxLength(64);
            entity.Property(e => e.PostCode).HasMaxLength(20);
            entity.Property(e => e.Street).HasMaxLength(255);
            entity.Property(e => e.Building).HasMaxLength(20);
        }
    }
}
