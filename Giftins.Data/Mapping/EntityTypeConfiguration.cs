using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Giftins.Core.Configuration;
using Giftins.Core.Infrastructure;

namespace Giftins.Data.Mapping
{
    public abstract class EntityTypeConfiguration
    {
        private readonly GiftinsConfig _gconfig;

        public EntityTypeConfiguration(GiftinsConfig gconfig)
        {
            _gconfig = gconfig;
        }

        public abstract string TableName { get; }

        public string FullTableName => $"{_gconfig.TablePrefix}{TableName}";


        public abstract void OnModelCreating(ModelBuilder builder);
    }

    public abstract class EntityTypeConfiguration<T> : EntityTypeConfiguration
        where T: class
    {
        public EntityTypeConfiguration(GiftinsConfig gconfig) 
            : base(gconfig)
        { }

        public override void OnModelCreating(ModelBuilder builder)
        {
            var entity = builder.Entity<T>();
            entity.ToTable(FullTableName);

            MapEntity(entity);
        }

        protected abstract void MapEntity(EntityTypeBuilder<T> entity);
    }

    public static class EntityTypeConfigurationExtension
    {
        public static void Map<T>(this ModelBuilder builder, GiftinsConfig gconfig)
            where T: class
        {
            var type = AppDomainTypeFinder.Global
                .FindClassesOfType<EntityTypeConfiguration<T>>()
                .FirstOrDefault();
            if (type != null)
            {
                var ctor = type.GetConstructor(new[] { typeof(GiftinsConfig) });
                var inst = (EntityTypeConfiguration<T>)ctor.Invoke(new[] { gconfig });
                inst.OnModelCreating(builder);
            }
        }
    }
}
