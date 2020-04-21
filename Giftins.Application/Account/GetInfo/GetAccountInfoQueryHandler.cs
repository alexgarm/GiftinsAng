using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MediatR;

using Giftins.Core.Domain.User;
using Giftins.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Giftins.Application.Account.GetInfo
{
    public class GetAccountInfoQueryHandler : IRequestHandler<GetAccountInfoQuery, AccountInfoDto>
    {
        private readonly AccountDbContext _accountDbContext;

        public GetAccountInfoQueryHandler(AccountDbContext accountDbContext)
        {
            _accountDbContext = accountDbContext;
        }

        public async Task<AccountInfoDto> Handle(GetAccountInfoQuery request, CancellationToken cancellationToken)
        {
            var acc = await _accountDbContext.Users
                .Where(a => a.Id == request.AccountId)
                .Select(a => new { a.Language })
                .FirstOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);

            if (acc == null)
                throw new NotImplementedException();

            return new AccountInfoDto()
            {
                AccountId = request.AccountId,
                Country = null,
                Language = acc.Language
            };
        }
    }
}
