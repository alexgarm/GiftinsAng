using System;

namespace Giftins.Core.ComponentModel
{
    /// <summary>
    /// Request result
    /// </summary>
    public abstract class GRequestResult : GActionResult
    {
        /// <summary>
        /// Result of request
        /// </summary>
        public virtual object Result { get; protected set; }

        public static GRequestResult Success(object result) => GRequestResult<object>.Success(result);
    }

    /// <summary>
    /// Request result
    /// </summary>
    /// <typeparam name="T">Result type</typeparam>
    public class GRequestResult<T> : GRequestResult
    {
        /// <summary>
        /// Result of request
        /// </summary>
        public new T Result
        {
            get => base.Result != null ? (T)base.Result : default(T);
            set => base.Result = value;
        }

        public static GRequestResult<T> Success(T result)
        {
            if (result == null)
                throw new ArgumentNullException(nameof(result));

            return new GRequestResult<T>()
            {
                Succeeded = true,
                Result = result
            };
        }

        public static new GRequestResult<T> Failed(GiftinsErrorResponse error)
        {
            if (error == null)
                throw new ArgumentNullException(nameof(error));

            return new GRequestResult<T>()
            {
                Succeeded = false,
                Error = error
            };
        }
    }
}
