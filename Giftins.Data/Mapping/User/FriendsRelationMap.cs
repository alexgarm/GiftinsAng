using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Giftins.Core.Configuration;
using Giftins.Core.Domain.User;

namespace Giftins.Data.Mapping.User
{
    public class FriendsRelationMap : EntityTypeConfiguration<FriendsRelation>
    {
        public override string TableName => "UserRelations";

        public FriendsRelationMap(GiftinsConfig gconfig)
            : base(gconfig)
        { }

        protected override void MapEntity(EntityTypeBuilder<FriendsRelation> entity)
        {
            entity.HasKey(e => new { e.Id_UserA, e.Id_UserB });

            entity.Property(e => e.Id_UserA)
                .HasMaxLength(36)
                .ValueGeneratedNever();
            entity.Property(e => e.Id_UserB)
                .HasMaxLength(36)
                .ValueGeneratedNever();

            entity.Property(e => e.State).IsRequired();
            entity.Property(e => e.SetUtc).IsRequired();
        }
    }

    public static class FriendsRelationMapExtension
    {
        public static void MapGiftinsFriendsRelation<T>(this ModelBuilder builder, GiftinsConfig gconfig)
            where T: FriendsRelation
        {
            new FriendsRelationMap(gconfig).OnModelCreating(builder);
        }
    }
}
