using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MediatR;

using Giftins.Data;
using Giftins.Core.Domain.User;
using Giftins.Core.Exceptions;

namespace Giftins.Application.Account.SetInfo
{
    public class SetAccountInfoCommandHandler : IRequestHandler<SetAccountInfoCommand>
    {
        private readonly UserManager<GiftinsUser> _userManager;

        public SetAccountInfoCommandHandler(UserManager<GiftinsUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(SetAccountInfoCommand request, CancellationToken cancellationToken)
        {
            var acc = await _userManager.FindByIdAsync(request.AccountId)
                .ConfigureAwait(false);

            if (acc == null)
                throw new GiftinsBadRequestException($"Account '{request.AccountId}' does not exist.");

            await _userManager.UpdateAsync(acc)
                .ConfigureAwait(false);

            return Unit.Value;
        }
    }
}
