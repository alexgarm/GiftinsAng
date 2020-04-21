using System;
using System.Collections.Generic;
using System.IO;
using MediatR;

namespace Giftins.Application.Media.UploadPicture
{
    public class UploadPictureQuery : IRequest<string>
    {
        public string UserId { get; set; }

        public string ContentType { get; set; }

        public string FileName { get; set; }

        public Stream ImageStream { get; set; }
    }
}
