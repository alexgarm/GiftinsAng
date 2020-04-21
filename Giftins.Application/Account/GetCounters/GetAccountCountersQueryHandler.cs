using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Giftins.Application.Account.GetCounters
{
    public class GetAccountCountersQueryHandler : IRequestHandler<GetAccountCountersQuery, AccountCountersDto>
    {
        public Task<AccountCountersDto> Handle(GetAccountCountersQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
