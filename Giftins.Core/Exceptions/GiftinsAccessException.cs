using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Core.Exceptions
{
    public class GiftinsAccessException : GiftinsException
    {
        public GiftinsAccessException()
            : base(GiftinsErrorCode.Restricted)
        {

        }

        public GiftinsAccessException(string message)
            : base(GiftinsErrorCode.Restricted, message)
        {

        }

        public GiftinsAccessException(string message, Exception innerException)
            : base(GiftinsErrorCode.Restricted, message, innerException)
        {

        }
    }
}
