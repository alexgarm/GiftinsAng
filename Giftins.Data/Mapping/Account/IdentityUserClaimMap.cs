using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Giftins.Core.Configuration;

namespace Giftins.Data.Mapping.Account
{
    public class IdentityUserClaimMap : EntityTypeConfiguration<IdentityUserClaim<string>>
    {
        public override string TableName => "UserClaims";

        public IdentityUserClaimMap(GiftinsConfig gconfig)
            : base(gconfig)
        { }

        protected override void MapEntity(EntityTypeBuilder<IdentityUserClaim<string>> entity)
        {

        }
    }
}
