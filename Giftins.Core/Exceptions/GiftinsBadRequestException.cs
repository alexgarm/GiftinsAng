using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Core.Exceptions
{
    public class GiftinsBadRequestException : GiftinsException
    {
        public GiftinsBadRequestException()
            : base(GiftinsErrorCode.BadRequest)
        {

        }

        public GiftinsBadRequestException(string message)
            : base(GiftinsErrorCode.BadRequest, message)
        {

        }

        public GiftinsBadRequestException(string message, Exception innerException)
            : base(GiftinsErrorCode.BadRequest, message, innerException)
        {

        }
    }
}
