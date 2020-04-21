using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Application.Account.GetInfo
{
    public class AccountInfoDto
    {
        /// <summary>
        /// Id of user account
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// Country based on authorization/session IP address
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Current user language
        /// </summary>
        public string Language { get; set; }
    }
}
