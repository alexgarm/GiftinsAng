using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Application.Account
{
    public class AccountDto
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public bool Enabled { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public bool EmailConfirmed { get; set; }
        public bool PhoneNumberConfirmed { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public bool LockoutEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }


        public int AccessFailedCount { get; set; }
    }
}
