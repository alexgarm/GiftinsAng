using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Giftins.Application.Account.AddRoles
{
    public class AddAccountRolesCommand : IRequest
    {
        /// <summary>
        /// Id of user that sending command
        /// </summary>
        public string RequesterId { get; set; }

        /// <summary>
        /// User account Id
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// Id of roles to add to user
        /// </summary>
        public IEnumerable<string> RoleIds { get; set; }
    }
}
