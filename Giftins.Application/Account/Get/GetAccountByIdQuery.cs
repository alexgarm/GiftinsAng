using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Giftins.Application.Account.Get
{
    /// <summary>
    /// Get user account by Id
    /// </summary>
    public class GetAccountByIdQuery : IRequest<AccountDto>
    {
        /// <summary>
        /// User account Id
        /// </summary>
        public string AccountId { get; set; }
    }
}
