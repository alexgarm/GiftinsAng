using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Giftins.Application.Account.Get
{
    /// <summary>
    /// Get user account by UserName
    /// </summary>
    public class GetAccountByUsernameQuery : IRequest<AccountDto>
    {
        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }
    }
}
