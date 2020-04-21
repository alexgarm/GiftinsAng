using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Giftins.Application.Account.Roles
{
    /// <summary>
    /// Get list of account roles 
    /// </summary>
    public class GetAccountRolesQuery : IRequest<IEnumerable<AccountRoleDto>>
    {
        /// <summary>
        /// Id of user that requesting data
        /// </summary>
        public string RequesterId { get; set; }

        /// <summary>
        /// User accound Id
        /// </summary>
        public string AccountId { get; set; }
    }
}
