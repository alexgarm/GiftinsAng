using System;
using System.Collections.Generic;
using System.Text;

using Giftins.Core.Domain.User;

namespace Giftins.Application.Account.GetProfileInfo
{
    public class ProfileInfoDto
    {
        public string AccountId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string ImageUrl { get; set; }

        public Gender Gender { get; set; }

        public Relation Relation { get; set; }

        public DateTime? Birthdate { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
    }
}
