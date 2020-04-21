using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Giftins.Core.Configuration;
using Giftins.Core.Domain.Media;

namespace Giftins.Data.Mapping.Media
{
    public class PictureMap : EntityTypeConfiguration<Picture>
    {
        public override string TableName => "Pictures";

        public PictureMap(GiftinsConfig gconfig)
            : base(gconfig)
        { }

        protected override void MapEntity(EntityTypeBuilder<Picture> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasValueGenerator<GuidValueGenerator>()
                .ValueGeneratedOnAdd();

            entity.Property(e => e.UserId)
                .HasMaxLength(36)
                .IsRequired();

            entity.Property(e => e.UploadUtc)
                .IsRequired();

            entity.Property(e => e.Photo75)
                .HasMaxLength(256)
                .IsRequired();
            entity.Property(e => e.Photo280)
                .HasMaxLength(256)
                .IsRequired();
            entity.Property(e => e.Photo600)
                .HasMaxLength(256)
                .IsRequired();
            entity.Property(e => e.PhotoSrc)
                .HasMaxLength(256)
                .IsRequired();

            entity.Property(e => e.Width).IsRequired();
            entity.Property(e => e.Height).IsRequired();

            entity.HasIndex(e => e.UserId);
        }
    }

    public static class PictureMapExtension
    {
        public static void MapGiftinsPicture<T>(this ModelBuilder builder, GiftinsConfig gconfig)
            where T: Picture
        {
            new PictureMap(gconfig).OnModelCreating(builder);
        }
    }
}
