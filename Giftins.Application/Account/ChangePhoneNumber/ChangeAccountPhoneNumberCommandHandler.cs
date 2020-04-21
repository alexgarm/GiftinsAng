using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MediatR;

using Giftins.Core.Domain.User;

namespace Giftins.Application.Account.ChangePhoneNumber
{
    public class ChangeAccountPhoneNumberCommandHandler : IRequestHandler<ChangeAccountPhoneNumberCommand>
    {
        private readonly UserManager<GiftinsUser> _userManager;

        public ChangeAccountPhoneNumberCommandHandler(UserManager<GiftinsUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(ChangeAccountPhoneNumberCommand request, CancellationToken cancellationToken)
        {
            var account = await _userManager.FindByIdAsync(request.AccountId).ConfigureAwait(false);

            if (account == null)
                throw new NotImplementedException();

            var res = await _userManager.ChangePhoneNumberAsync(account, request.PhoneNumber, request.ConfirmationCode)
                .ConfigureAwait(false);

            if (res.Succeeded)
                return Unit.Value;

            throw new NotImplementedException();
        }
    }
}
