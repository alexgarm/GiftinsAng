using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Giftins.Application.Media.GetUploadServer
{
    public class GetUplaodServerQueryHandler : IRequestHandler<GetUploadServerQuery, string>
    {
        public Task<string> Handle(GetUploadServerQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
