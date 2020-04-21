using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Giftins.Core.Configuration;
using Giftins.Core.Domain.User;

namespace Giftins.Data.Mapping.Account
{
    public class GiftinsRoleMap : EntityTypeConfiguration<GiftinsRole>
    {
        public override string TableName => "Roles";

        public GiftinsRoleMap(GiftinsConfig gconfig) 
            : base(gconfig)
        { }
        
        protected override void MapEntity(EntityTypeBuilder<GiftinsRole> entity)
        {
            entity.Property(e => e.Id)
                .HasMaxLength(36);
        }
    }

    public static class GiftinsRoleMapExtension
    {
        public static void MapGiftinsRoles<T>(this ModelBuilder builder, GiftinsConfig gconfig)
            where T : GiftinsRole
        {
            new GiftinsRoleMap(gconfig).OnModelCreating(builder);
        }
    }
}
