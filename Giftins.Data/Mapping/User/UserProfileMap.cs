using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Giftins.Core.Configuration;
using Giftins.Core.Domain.User;

namespace Giftins.Data.Mapping.User
{
    public class UserProfileMap : EntityTypeConfiguration<UserProfile>
    {

        public override string TableName => "Profiles";

        public UserProfileMap(GiftinsConfig gconfig) 
            : base(gconfig)
        { }

        protected override void MapEntity(EntityTypeBuilder<UserProfile> entity)
        {
            entity.HasKey(e => e.UserId);
            entity.Property(e => e.UserId)
                .HasMaxLength(36);

            entity.Property(e => e.FirstName)
                .HasMaxLength(64)
                .IsRequired()
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(64)
                .HasColumnName("last_name");

            entity.Property(e => e.PictureId)
                .HasMaxLength(36)
                .HasColumnName("pic_id");

            entity.Property(e => e.GenderId).HasColumnName("gender");
            entity.Property(e => e.Birthdate).HasColumnName("bdate");
            entity.Property(e => e.RelationId).HasColumnName("relation"); ;

            entity.Property(e => e.BirthDisplayPolicyId).HasColumnName("bdate_disp");
            entity.Property(e => e.RelationDisplayPolicyId).HasColumnName("relation_disp");

            entity.Ignore(e => e.BirthDisplayPolicy);
            entity.Ignore(e => e.RelationDisplayPolicy);
        }
    }
}
