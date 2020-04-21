using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Giftins.Core.Configuration;
using Giftins.Core.Domain.User;

namespace Giftins.Data.Mapping.User
{
    public class UserSubscriptionMap : EntityTypeConfiguration<UserSubscription>
    {
        public override string TableName => "UserSubscriptions";

        public UserSubscriptionMap(GiftinsConfig gconfig)
            : base(gconfig)
        { }

        protected override void MapEntity(EntityTypeBuilder<UserSubscription> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id_User).IsRequired();
            entity.Property(e => e.Id_Target).IsRequired();

            entity.Property(e => e.Birthday).IsRequired();
            entity.Property(e => e.Important).IsRequired();
            entity.Property(e => e.Personal).IsRequired();
            entity.Property(e => e.Family).IsRequired();
            entity.Property(e => e.Friends).IsRequired();
            entity.Property(e => e.Other).IsRequired();
        }
    }

    public static class UserSubscriptionMapExtension
    {
        public static void MapGiftinsUserSubscription<T>(this ModelBuilder builder, GiftinsConfig gconfig)
            where T : UserSubscription
        {
            new UserSubscriptionMap(gconfig).OnModelCreating(builder);
        }
    }
}
