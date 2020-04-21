using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Core.Domain.User
{
    public class GiftinsRole : IdentityRole
    {
        public const string ROOT = "root";
        public const string ADMIN = "administrator";
        public const string VENDOR = "vendor";
        public const string MANAGER = "manager";

        /// <summary>
        /// EF
        /// </summary>
        protected GiftinsRole()
        { }

        public GiftinsRole(string name)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
