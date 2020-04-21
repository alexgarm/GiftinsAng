using System;
using Newtonsoft.Json;

using Giftins.Core.Exceptions;

namespace Giftins.Core.ComponentModel
{
    public class GiftinsErrorResponse
    {
        public const string MSG_UNKNOWN_DEFAULT = "UNKNOWN_ERROR_MESSAGE";
        public const string MSG_BAD_REQUEST_DEFAULT = "BAD_REQUEST_MESSAGE";
        public const string MSG_INTERNAL_ERROR_DEFAULT = "INTERNAL_SERVER_ERROR_MESSAGE";
        public const string MSG_RESTRICKED_DEFAULT = "ACCESS_RESTRICTED_MESSAGE";

        [JsonProperty(PropertyName = "CODE")]
        public GiftinsErrorCode ErrorCode { get; protected set; }

        [JsonProperty(PropertyName = "MSG")]
        public string Message { get; protected set; }

        protected GiftinsErrorResponse() { }
        public GiftinsErrorResponse(GiftinsErrorCode code, string message)
        {
            ErrorCode = code;
            Message = message;
        }

        #region Errors

        public static GiftinsErrorResponse Unknown()
        {
            return new GiftinsErrorResponse()
            {
                ErrorCode = GiftinsErrorCode.UnknownError,
                Message = MSG_UNKNOWN_DEFAULT
            };
        }
        public static GiftinsErrorResponse Unknown(string message)
        {
            ThrowIfNoMessage(message);
            return new GiftinsErrorResponse()
            {
                ErrorCode = GiftinsErrorCode.UnknownError,
                Message = message
            };
        }

        public static GiftinsErrorResponse BadRequest()
        {
            return new GiftinsErrorResponse()
            {
                ErrorCode = GiftinsErrorCode.BadRequest,
                Message = MSG_BAD_REQUEST_DEFAULT
            };
        }
        public static GiftinsErrorResponse BadRequest(string message)
        {
            ThrowIfNoMessage(message);
            return new GiftinsErrorResponse()
            {
                ErrorCode = GiftinsErrorCode.BadRequest,
                Message = message
            };
        }

        public static GiftinsErrorResponse InternalError()
        {
            return new GiftinsErrorResponse()
            {
                ErrorCode = GiftinsErrorCode.InternalServerError,
                Message = MSG_INTERNAL_ERROR_DEFAULT
            };
        }
        public static GiftinsErrorResponse InternalError(string message)
        {
            ThrowIfNoMessage(message);
            return new GiftinsErrorResponse()
            {
                ErrorCode = GiftinsErrorCode.InternalServerError,
                Message = message
            };
        }

        public static GiftinsErrorResponse Restricted()
        {
            return new GiftinsErrorResponse()
            {
                ErrorCode = GiftinsErrorCode.Restricted,
                Message = MSG_RESTRICKED_DEFAULT
            };
        }
        public static GiftinsErrorResponse Restricted(string message)
        {
            ThrowIfNoMessage(message);
            return new GiftinsErrorResponse()
            {
                ErrorCode = GiftinsErrorCode.Restricted,
                Message = message
            };
        }

        #endregion

        protected static void ThrowIfNoMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(message);
        }
    }
}
