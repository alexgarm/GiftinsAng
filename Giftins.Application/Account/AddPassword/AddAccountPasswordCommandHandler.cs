using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MediatR;

using Giftins.Core.Domain.User;

namespace Giftins.Application.Account.AddPassword
{
    public class AddAccountPasswordCommandHandler : IRequestHandler<AddAccountPasswordCommand>
    {
        private readonly UserManager<GiftinsUser> _userManager;

        public AddAccountPasswordCommandHandler(UserManager<GiftinsUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(AddAccountPasswordCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Password))
                throw new NotImplementedException();

            var account = await _userManager.FindByIdAsync(request.AccountId)
                .ConfigureAwait(false);

            if (account == null)
                throw new NotImplementedException();

            var res = await _userManager.AddPasswordAsync(account, request.Password)
                .ConfigureAwait(false);

            if (res.Succeeded)
                return Unit.Value;

            throw new NotImplementedException(string.Join(";", res.Errors));
        }
    }
}
