using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Giftins.Application.Media.GetUploadServer
{
    public class GetUploadServerQuery : IRequest<string>
    {
        public string UserId { get; set; }
    }
}
