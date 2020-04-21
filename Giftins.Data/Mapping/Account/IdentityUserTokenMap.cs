using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Giftins.Core.Configuration;

namespace Giftins.Data.Mapping.Account
{
    public class IdentityUserTokenMap : EntityTypeConfiguration<IdentityUserToken<string>>
    {

        public override string TableName => "UserTokens";

        public IdentityUserTokenMap(GiftinsConfig gconfig)
            : base(gconfig)
        { }

        protected override void MapEntity(EntityTypeBuilder<IdentityUserToken<string>> entity)
        {

        }
    }
}
