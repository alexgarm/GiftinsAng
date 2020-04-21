using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Giftins.Core.Configuration;

namespace Giftins.Data.Mapping.Account
{
    public class IdentityUserRoleMap : EntityTypeConfiguration<IdentityUserRole<string>>
    {
        public override string TableName => "UserRoles";

        public IdentityUserRoleMap(GiftinsConfig gconfig)
            : base(gconfig)
        { }

        protected override void MapEntity(EntityTypeBuilder<IdentityUserRole<string>> entity)
        {

        }
    }
}
