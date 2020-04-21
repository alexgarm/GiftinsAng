using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Giftins.Application.Account.AddPassword
{
    public class AddAccountPasswordCommand : IRequest
    {
        /// <summary>
        /// User account Id
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// New user password
        /// </summary>
        public string Password { get; set; }
    }
}
