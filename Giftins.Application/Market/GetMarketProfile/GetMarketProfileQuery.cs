using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Giftins.Application.Market.GetMarketProfile
{
    public class GetMarketProfileQuery : IRequest<MarketProfileDTO>
    {
        public string UserId { get; set; }


    }
}
