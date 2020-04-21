using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Giftins.Core.Configuration;

namespace Giftins.Data.Mapping.Account
{
    public class IdentityRoleClaimMap : EntityTypeConfiguration<IdentityRoleClaim<string>>
    {
        public override string TableName => "RoleClaims";

        public IdentityRoleClaimMap(GiftinsConfig gconfig) 
            : base(gconfig)
        { }

        protected override void MapEntity(EntityTypeBuilder<IdentityRoleClaim<string>> entity)
        {

        }
    }
}
