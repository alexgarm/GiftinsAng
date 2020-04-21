using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Giftins.Core.Domain.User;

namespace Giftins.Web.ViewComponents.UserProfile
{
    public class UserProfileViewModel
    {
        public string PictureUrl { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Name => string.Join(" ", new[] { LastName, FirstName });

        public Gender Gender { get; set; }

        public DateTime? Birthdate { get; set; }
    }
}
