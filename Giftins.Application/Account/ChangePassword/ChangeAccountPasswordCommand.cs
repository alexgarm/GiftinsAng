using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Giftins.Application.Account.ChangePassword
{
    public class ChangeAccountPasswordCommand : IRequest
    {
        /// <summary>
        /// User account Id
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// Old account password
        /// </summary>
        public string OldPassword { get; set; }

        /// <summary>
        /// New account password
        /// </summary>
        public string NewPassword { get; set; }
    }
}
