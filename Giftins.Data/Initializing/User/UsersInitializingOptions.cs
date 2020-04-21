using System;
using System.Collections.Generic;
using System.Text;

using Giftins.Core.Domain.User;

namespace Giftins.Data.UserContext.Initializing
{
    public class UsersInitializingOptions
    {
        public RootUserInitializingOptions Root { get; protected set; } = new RootUserInitializingOptions();
        public ICollection<UserInitializingOptions> Users { get; protected set; } = new List<UserInitializingOptions>();
    }

    public class UserInitializingOptions
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IList<string> Roles { get; set; } = new List<string>();
    }

    public class RootUserInitializingOptions
    {
        /// <summary>
        /// Allow to contain multiple users with <see cref="RootRole"/>
        /// </summary>
        public bool AllowMultipleRoot { get; set; } = false;

        /// <summary>
        /// Root role
        /// </summary>
        public string RootRole { get; set; } = GiftinsRole.ROOT;

        public string RootLogin { get; set; } = "admin";
        public string RootPassword { get; set; } = "password";

        public string RootEmail { get; set; } = "admin@giftins.com";

        public string RootFirstName { get; set; } = "Root";
        public string RootLastName { get; set; } = "Administrator";

        /// <summary>
        /// Add root user to roles
        /// </summary>
        public IList<string> RootRoles { get; set; } = new List<string>()
        {
            GiftinsRole.ROOT
        };
    }
}
