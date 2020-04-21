using System;
using System.Collections.Generic;
using System.Linq;

using Giftins.Core.ComponentModel;

namespace Giftins.Core.Exceptions
{
    public sealed class GiftinsErrorCode : ClassEnumeration<GiftinsErrorCode>
    {
        public const string UNKNOWN_ERROR_NAME = "unknown_error";
        public const string INTERNAL_ERROR_NAME = "internal_error";
        public const string BAD_REQUEST_NAME = "bad_request";
        public const string RESTRICTED_NAME = "restricted";

        /// <summary>
        /// Unknown error occuret while processing
        /// </summary>
        public static readonly GiftinsErrorCode UnknownError = new GiftinsErrorCode(0, UNKNOWN_ERROR_NAME);
        /// <summary>
        /// Internal server error. May work if try again later
        /// </summary>
        public static readonly GiftinsErrorCode InternalServerError = new GiftinsErrorCode(50, INTERNAL_ERROR_NAME);
        /// <summary>
        /// One or more request parameters are mission or incorrect
        /// </summary>
        public static readonly GiftinsErrorCode BadRequest = new GiftinsErrorCode(100, BAD_REQUEST_NAME);
        /// <summary>
        /// Initiator do not have permission to execute this operation
        /// </summary>
        public static readonly GiftinsErrorCode Restricted = new GiftinsErrorCode(200, RESTRICTED_NAME);

        private GiftinsErrorCode(int id, string name)
            : base(id, name)
        { }
    }
}
