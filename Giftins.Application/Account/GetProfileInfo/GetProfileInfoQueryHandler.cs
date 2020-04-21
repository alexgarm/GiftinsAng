using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

using Giftins.Data;

namespace Giftins.Application.Account.GetProfileInfo
{
    public class GetProfileInfoQueryHandler : IRequestHandler<GetProfileInfoQuery, ProfileInfoDto>
    {
        private readonly AccountDbContext _accountDbContext;

        public GetProfileInfoQueryHandler(AccountDbContext accountDbContext)
        {
            _accountDbContext = accountDbContext;
        }

        string pictureUrl = "/img/profile.png"; // Get picture from pictureService/cache

        public async Task<ProfileInfoDto> Handle(GetProfileInfoQuery request, CancellationToken cancellationToken)
        {
            var profile = await _accountDbContext.UserProfiles
                .FindAsync(request.AccountId);

            if (profile == null)
                throw new NotImplementedException();

            return new ProfileInfoDto()
            {
                AccountId = request.AccountId,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                ImageUrl = pictureUrl,
                Birthdate = profile.Birthdate,
                Gender = profile.Gender,
                Relation = profile.Relation,
            };
        }
    }
}
