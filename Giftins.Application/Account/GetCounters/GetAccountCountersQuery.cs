using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Giftins.Application.Account.GetCounters
{
    public class GetAccountCountersQuery : IRequest<AccountCountersDto>
    {
        /// <summary>
        /// User account Id
        /// </summary>
        public string AccountId { get; set; }
    }
}
