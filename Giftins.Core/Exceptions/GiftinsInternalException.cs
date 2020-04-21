using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Core.Exceptions
{
    public class GiftinsInternalException : GiftinsException
    {
        public GiftinsInternalException()
            : base(GiftinsErrorCode.InternalServerError)
        {

        }

        public GiftinsInternalException(string message)
            : base(GiftinsErrorCode.InternalServerError, message)
        {

        }

        public GiftinsInternalException(string message, Exception innerException)
            : base(GiftinsErrorCode.InternalServerError, message, innerException)
        {

        }
    }
}
