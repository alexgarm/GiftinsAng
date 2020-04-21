using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Application.Account.Roles
{
    public class AccountRoleDto
    {
        /// <summary>
        /// Id of user account
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// Id of role
        /// </summary>
        public string RoleId { get; set; }
        /// <summary>
        /// Role name
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// Role description
        /// </summary>
        public string RoleDescription { get; set; }

        /// <summary>
        /// Indicates whether requester is allowed to delete this role
        /// </summary>
        public bool CanDelete { get; set; }
    }
}
