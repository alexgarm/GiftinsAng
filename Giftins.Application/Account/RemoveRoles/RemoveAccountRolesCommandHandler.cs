using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Giftins.Application.Account.RemoveRoles
{
    public class RemoveAccountRolesCommandHandler : IRequestHandler<RemoveAccountRolesCommand>
    {
        public Task<Unit> Handle(RemoveAccountRolesCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
