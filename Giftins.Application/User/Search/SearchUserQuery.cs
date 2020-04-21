using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Giftins.Application.User.Search
{
    public class SearchUserQuery : IRequest
    {
        public string Query { get; set; }
    }
}
