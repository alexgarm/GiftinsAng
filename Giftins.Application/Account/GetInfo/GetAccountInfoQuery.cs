using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Giftins.Application.Account.GetInfo
{
    /// <summary>
    /// Return account information
    /// </summary>
    public class GetAccountInfoQuery : IRequest<AccountInfoDto>
    {
        /// <summary>
        /// Id of user account
        /// </summary>
        public string AccountId { get; set; }
    }
}
