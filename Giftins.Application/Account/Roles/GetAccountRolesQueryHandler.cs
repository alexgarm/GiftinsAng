using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Giftins.Application.Account.Roles
{
    public class GetAccountRolesQueryHandler : IRequestHandler<GetAccountRolesQuery, IEnumerable<AccountRoleDto>>
    {
        public Task<IEnumerable<AccountRoleDto>> Handle(GetAccountRolesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
