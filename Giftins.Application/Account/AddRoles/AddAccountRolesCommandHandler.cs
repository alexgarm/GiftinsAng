using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MediatR;

using Giftins.Core.Domain.User;

namespace Giftins.Application.Account.AddRoles
{
    public class AddAccountRolesCommandHandler : IRequestHandler<AddAccountRolesCommand>
    {
        private readonly UserManager<GiftinsUser> _userManager;
        private readonly RoleManager<GiftinsRole> _roleManager;

        public AddAccountRolesCommandHandler(UserManager<GiftinsUser> userManager, RoleManager<GiftinsRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public Task<Unit> Handle(AddAccountRolesCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
