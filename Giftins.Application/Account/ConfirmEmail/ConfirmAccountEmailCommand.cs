using System;
using System.Collections.Generic;
using MediatR;

namespace Giftins.Application.Account.ConfirmEmail
{
    public class ConfirmAccountEmailCommand : IRequest
    {
        /// <summary>
        /// User account Id
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// Code recieved in email
        /// </summary>
        public string ConfirmationCode { get; set; }
    }
}
