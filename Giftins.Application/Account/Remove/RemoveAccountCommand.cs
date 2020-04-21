using System;
using System.Collections.Generic;
using MediatR;

namespace Giftins.Application.Account.Remove
{
    /// <summary>
    /// Remove user account from system
    /// </summary>
    public class RemoveAccountCommand : IRequest
    {
        /// <summary>
        /// User account Id
        /// </summary>
        public string AccountId { get; set; }
    }
}
