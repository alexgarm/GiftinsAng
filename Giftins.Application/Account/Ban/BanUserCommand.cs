using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Giftins.Application.Account.Ban
{
    public class BanUserCommand : IRequest
    {
        /// <summary>
        /// User account Id
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// Id of user account to ban
        /// </summary>
        public string BanAccountId { get; set; }
    }
}
