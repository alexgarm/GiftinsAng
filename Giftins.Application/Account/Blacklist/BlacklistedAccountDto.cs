using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Application.Account.Blacklist
{
    public class BlacklistedAccountDto
    {
        /// <summary>
        /// Blacklisted user account Id
        /// </summary>
        public string AccountId { get; set; }
        /// <summary>
        /// Blacklisted user name
        /// </summary>
        public string Name { get; set; }
    }
}
