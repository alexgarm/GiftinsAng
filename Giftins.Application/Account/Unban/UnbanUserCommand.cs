using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Giftins.Application.Account.Unban
{
    public class UnbanUserCommand : IRequest
    {
        /// <summary>
        /// Id of user account to change properties
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// Id of user account to remove from blacklist
        /// </summary>
        public string UnbanAccountId { get; set; }
    }
}
