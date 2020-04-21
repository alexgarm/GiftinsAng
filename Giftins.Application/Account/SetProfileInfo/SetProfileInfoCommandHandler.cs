using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediatR;

using Giftins.Data;

namespace Giftins.Application.Account.SetProfileInfo
{
    public class SetProfileInfoCommandHandler : IRequestHandler<SetProfileInfoCommand>
    {
        private readonly AccountDbContext _accountDbContext;

        public SetProfileInfoCommandHandler(AccountDbContext accountDbContext)
        {
            _accountDbContext = accountDbContext;
        }

        public async Task<Unit> Handle(SetProfileInfoCommand request, CancellationToken cancellationToken)
        {
            var profile = await _accountDbContext.UserProfiles
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            await _accountDbContext.SaveChangesAsync()
                .ConfigureAwait(false);

            return Unit.Value;
        }
    }
}
