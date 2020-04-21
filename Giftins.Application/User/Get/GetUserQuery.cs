using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Giftins.Application.User.Get
{
    public class GetUserQuery : IRequest
    {
        public string UserName { get; set; }
    }
}
