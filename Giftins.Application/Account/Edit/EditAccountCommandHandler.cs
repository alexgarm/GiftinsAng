using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MediatR;

using Giftins.Core.Domain.User;
using Giftins.Core.Exceptions;
using Giftins.Data;

namespace Giftins.Application.Account.Edit
{
    public class EditAccountCommandHandler : IRequestHandler<EditAccountCommand>
    {
        private readonly AccountDbContext _accountDbContext;
        private readonly UserManager<GiftinsUser> _userManager;

        public EditAccountCommandHandler(AccountDbContext accountDbContext, UserManager<GiftinsUser> userManager)
        {
            _accountDbContext = accountDbContext;
            _userManager = userManager;
        }

        public async Task<Unit> Handle(EditAccountCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.AccountId))
                throw new ArgumentNullException(nameof(request.AccountId));

            var user = await _userManager.FindByIdAsync(request.AccountId)
                .ConfigureAwait(false);

            if (user == null)
                throw new GiftinsBadRequestException($"Account not found.");

            bool changeSecurityStamp = false;

            if (user.Enabled != request.Enabled)
            {
                user.Enabled = request.Enabled;
                if (request.Enabled == false)
                    changeSecurityStamp = true;
            }

            if (user.Email != request.Email)
            {
                user.Email = request.Email;
                changeSecurityStamp = true;
            }

            if (user.PhoneNumber != request.PhoneNumber)
            {
                user.PhoneNumber = request.PhoneNumber;
                changeSecurityStamp = true;
            }

            user.EmailConfirmed = request.EmailConfirmed;
            user.PhoneNumberConfirmed = request.PhoneNumberConfirmed;

            if (user.LockoutEnabled != request.LockoutEnabled)
            {
                user.LockoutEnabled = request.LockoutEnabled;
                if (request.LockoutEnabled == true)
                    changeSecurityStamp = true;
            }

            if (user.LockoutEnd != request.LockoutEnd)
            {
                if (request.LockoutEnd != null && request.LockoutEnd < user.LockoutEnd)
                    changeSecurityStamp = true;

                user.LockoutEnd = request.LockoutEnd;
            }

            if (changeSecurityStamp)
                user.SecurityStamp = Guid.NewGuid().ToString();

            var res = await _userManager.UpdateAsync(user).ConfigureAwait(false);
            if (!res.Succeeded)
            {
                throw new NotImplementedException();
            }

            return Unit.Value;
        }
    }
}
