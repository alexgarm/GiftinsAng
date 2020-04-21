using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MediatR;

using Giftins.Core.Domain.User;

namespace Giftins.Application.Account.ChangePassword
{
    public class ChangeAccountPasswordCommandHandler : IRequestHandler<ChangeAccountPasswordCommand>
    {
        private readonly UserManager<GiftinsUser> _userManager;

        public ChangeAccountPasswordCommandHandler(UserManager<GiftinsUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(ChangeAccountPasswordCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.OldPassword))
                throw new NotImplementedException();
            if (string.IsNullOrEmpty(request.NewPassword))
                throw new NotImplementedException();

            var account = await _userManager.FindByIdAsync(request.AccountId)
                .ConfigureAwait(false);

            if (account == null)
                throw new NotImplementedException();

            var res = await _userManager.ChangePasswordAsync(account, request.OldPassword, request.NewPassword)
                .ConfigureAwait(false);

            if (res.Succeeded)
                return Unit.Value;

            throw new NotImplementedException(string.Join(";", res.Errors));
        }
    }
}
