using System;
using System.Collections.Generic;
using MediatR;

namespace Giftins.Application.Account.RemoveRoles
{
    /// <summary>
    /// Remove roles from user account
    /// </summary>
    public class RemoveAccountRolesCommand : IRequest
    {
        /// <summary>
        /// Id of user that sending command
        /// </summary>
        public string RequesterId { get; set; }

        /// <summary>
        /// Id of user account to remove roles
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// Id of roles to remove from user
        /// </summary>
        public IEnumerable<string> RoleIds { get; set; }
    }
}
