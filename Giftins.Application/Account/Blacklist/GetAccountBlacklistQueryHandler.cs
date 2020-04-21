using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Giftins.Application.Account.Blacklist
{
    public class GetAccountBlacklistQueryHandler : IRequestHandler<GetAccountBlacklistQuery, IEnumerable<BlacklistedAccountDto>>
    {
        public Task<IEnumerable<BlacklistedAccountDto>> Handle(GetAccountBlacklistQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
