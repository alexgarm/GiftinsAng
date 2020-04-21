using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Giftins.Application.Media.UploadPicture
{
    public class UploadPictureQueryHandler : IRequestHandler<UploadPictureQuery, string>
    {
        public Task<string> Handle(UploadPictureQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
