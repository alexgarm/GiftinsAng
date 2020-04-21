using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MediatR;

using Giftins.Core.Domain.User;

namespace Giftins.Application.Account.ConfirmEmail
{
    public class ConfirmAccountEmailCommandHandle : IRequestHandler<ConfirmAccountEmailCommand>
    {
        private readonly UserManager<GiftinsUser> _userManager;

        public ConfirmAccountEmailCommandHandle(UserManager<GiftinsUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(ConfirmAccountEmailCommand request, CancellationToken cancellationToken)
        {
            var account = await _userManager.FindByIdAsync(request.AccountId)
                .ConfigureAwait(false);

            if (account == null)
                throw new NotImplementedException();

            var res = await _userManager.ConfirmEmailAsync(account, request.ConfirmationCode)
                .ConfigureAwait(false);

            if (res.Succeeded)
                return Unit.Value;

            throw new NotImplementedException();
        }
    }
}
