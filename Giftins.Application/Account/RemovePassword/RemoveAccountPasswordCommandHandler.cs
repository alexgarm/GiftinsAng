using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using MediatR;

using Giftins.Core.Domain.User;
using System.Threading;
using System.Threading.Tasks;

namespace Giftins.Application.Account.RemovePassword
{
    public class RemoveAccountPasswordCommandHandler : IRequestHandler<RemoveAccountPasswordCommand>
    {
        private readonly UserManager<GiftinsUser> _userManager;

        public RemoveAccountPasswordCommandHandler(UserManager<GiftinsUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(RemoveAccountPasswordCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.InitiatorId))
                throw new NotImplementedException();

            var account = await _userManager.FindByIdAsync(request.AccountId)
                .ConfigureAwait(false);

            if (account == null)
                throw new NotImplementedException("Account not found");

            var res = await _userManager.RemovePasswordAsync(account)
                .ConfigureAwait(false);

            if (res.Succeeded)
                return Unit.Value;

            throw new NotImplementedException(string.Join(";", res.Errors));
        }
    }
}
