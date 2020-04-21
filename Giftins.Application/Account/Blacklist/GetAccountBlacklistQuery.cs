using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Giftins.Application.Account.Blacklist
{
    public class GetAccountBlacklistQuery : IRequest<IEnumerable<BlacklistedAccountDto>>
    {
        /// <summary>
        /// User account Id
        /// </summary>
        public string AccoundId { get; set; }
    }
}
