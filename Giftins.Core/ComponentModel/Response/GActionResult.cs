using System;

namespace Giftins.Core.ComponentModel
{
    /// <summary>
    /// Operation execution result
    /// </summary>
    public class GActionResult
    {
        /// <summary>
        /// Request executed successfuly
        /// </summary>
        public bool Succeeded { get; protected set; }

        /// <summary>
        /// Error information if request not executed successfuly
        /// </summary>
        public GiftinsErrorResponse Error { get; protected set; }

        protected GActionResult()
        { }

        public static GActionResult Success()
        {
            return new GActionResult()
            {
                Succeeded = true
            };
        }

        public static GActionResult Failed(GiftinsErrorResponse error)
        {
            var res = new GActionResult()
            {
                Succeeded = false,
                Error = error ?? throw new ArgumentNullException(nameof(error))
            };
            return res;
        }
    }
}
