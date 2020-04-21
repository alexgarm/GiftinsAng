using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Giftins.Application.Market.GetMarketProfile
{
    public class GetMarketProfileQueryHandler : IRequestHandler<GetMarketProfileQuery, MarketProfileDTO>
    {
        public Task<MarketProfileDTO> Handle(GetMarketProfileQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
