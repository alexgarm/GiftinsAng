using Giftins.Core.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Giftins.Data.Mapping.Account
{
    public class RoleClaimMap : EntityTypeConfiguration<IdentityRoleClaim<string>>
    {

        public override string TableName => "RoleClaims";

        public RoleClaimMap(GiftinsConfig gconfig)
            : base(gconfig)
        { }

        protected override void MapEntity(EntityTypeBuilder<IdentityRoleClaim<string>> entity)
        {

        }
    }
}
