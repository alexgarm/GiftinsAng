using System;
using System.Collections.Generic;
using MediatR;

namespace Giftins.Application.Account.ChangePhoneNumber
{
    public class ChangeAccountPhoneNumberCommand : IRequest
    {
        /// <summary>
        /// User account Id
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// Phone number to confirm
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Code recieved in SMS
        /// </summary>
        public string ConfirmationCode { get; set; }
    }
}
