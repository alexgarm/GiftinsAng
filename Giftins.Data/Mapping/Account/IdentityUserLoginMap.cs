using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Giftins.Core.Configuration;

namespace Giftins.Data.Mapping.Account
{
    public class IdentityUserLoginMap : EntityTypeConfiguration<IdentityUserLogin<string>>
    {
        public override string TableName => "UserLogins";

        public IdentityUserLoginMap(GiftinsConfig gconfig)
            : base(gconfig)
        { }

        protected override void MapEntity(EntityTypeBuilder<IdentityUserLogin<string>> entity)
        {

        }
    }
}
