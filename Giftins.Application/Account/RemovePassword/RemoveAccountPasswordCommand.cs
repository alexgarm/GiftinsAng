using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Giftins.Application.Account.RemovePassword
{
    public class RemoveAccountPasswordCommand : IRequest
    {
        /// <summary>
        /// User account Id
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// Id of user initiated password remove
        /// </summary>
        public string InitiatorId { get; set; }
    }
}
