using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Giftins.Application.Account.GetProfileInfo
{
    public class GetProfileInfoQuery : IRequest<ProfileInfoDto>
    {
        /// <summary>
        /// User account Id
        /// </summary>
        public string AccountId { get; set; }
    }
}
