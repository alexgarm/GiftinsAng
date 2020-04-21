using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MediatR;

using Giftins.Core.Domain.User;
using Giftins.Data;

namespace Giftins.Application.Account.Get
{
    public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, AccountDto>
    {
        private readonly AccountDbContext _accountDbContext;

        public GetAccountByIdQueryHandler(AccountDbContext accountDbContext)
        {
            _accountDbContext = accountDbContext;
        }

        public async Task<AccountDto> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
            var account = await _accountDbContext.Users
                .FirstOrDefaultAsync(a => a.Id == request.AccountId, cancellationToken)
                .ConfigureAwait(false);

            if (account != null)
            {
                var profile = await _accountDbContext.UserProfiles
                    .FirstAsync(p => p.UserId == account.Id, cancellationToken)
                    .ConfigureAwait(false);

                return new AccountDto()
                {
                    Id = account.Id,
                    UserName = account.UserName,
                    Enabled = account.Enabled,
                    Email = account.Email,
                    PhoneNumber = account.PhoneNumber,
                    EmailConfirmed = account.EmailConfirmed,
                    PhoneNumberConfirmed = account.PhoneNumberConfirmed,
                    FirstName = profile.FirstName,
                    LastName = profile.LastName,
                    LockoutEnabled = account.LockoutEnabled,
                    LockoutEnd = account.LockoutEnd,
                    AccessFailedCount = account.AccessFailedCount
                };
            }
            throw new NotImplementedException();
        }
    }
}
