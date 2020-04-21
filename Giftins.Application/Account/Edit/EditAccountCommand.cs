using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Giftins.Application.Account.Edit
{
    /// <summary>
    /// Edit account sensitive information
    /// </summary>
    public class EditAccountCommand : IRequest
    {
        /// <summary>
        /// Id of user account to change properties
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// Define whether account enabled at all
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Main account email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Email confirmation status
        /// </summary>
        public bool EmailConfirmed { get; set; }

        /// <summary>
        /// Main account phone number
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Phone number confirmation status
        /// </summary>
        public bool PhoneNumberConfirmed { get; set; }
        
        /// <summary>
        /// Indicating if the user could be locked out.
        /// </summary>
        public bool LockoutEnabled { get; set; }
        /// <summary>
        /// Date and time, in UTC, when user lockout ends.
        /// </summary>
        public DateTimeOffset? LockoutEnd { get; set; }
    }
}
