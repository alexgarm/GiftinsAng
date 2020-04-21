using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Core.Exceptions
{
    public class GiftinsException : Exception
    {
        public GiftinsErrorCode ErrorCode { get; protected set; }

        public GiftinsException()
        {
            ErrorCode = GiftinsErrorCode.UnknownError;
        }

        public GiftinsException(string message)
            : base(message)
        {
            ErrorCode = GiftinsErrorCode.UnknownError;
        }

        public GiftinsException(string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = GiftinsErrorCode.UnknownError;
        }

        public GiftinsException(GiftinsErrorCode errorCode)
            : base()
        {
            ErrorCode = errorCode;
        }

        public GiftinsException(GiftinsErrorCode errorCode, string message)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        public GiftinsException(GiftinsErrorCode errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
