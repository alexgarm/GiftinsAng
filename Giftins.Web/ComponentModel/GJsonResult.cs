using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Giftins.Core.ComponentModel;

namespace Giftins.Web.ComponentModel
{
    /// <summary>
    /// An action result which formats the given object as Giftins JSON Result
    /// </summary>
    public class GJsonResult : JsonResult
    {
        #region const
        public const string RESPONSE_KEY = "RESP";
        public const string RESULT_KEY = "RES";
        public const string ERROR_KEY = "ERROR";

        public const string RESPONSE_OK = "ok";
        public const string RESPONSE_FAIL = "fail";
        #endregion

        public new Dictionary<string, object> Value
        {
            get => (base.Value ?? (base.Value = new Dictionary<string, object>())) as Dictionary<string, object>;
            protected set => base.Value = value;
        }

        public string Response
        {
            get => Value.ContainsKey(RESPONSE_KEY) ? Value[RESPONSE_KEY] as string : null;
            protected set => Value[RESPONSE_KEY] = value;
        }

        public object Result
        {
            get => Value.ContainsKey(RESULT_KEY) ? Value[RESULT_KEY] : null;
            protected set
            {
                if (value != null)
                    Value[RESULT_KEY] = value;
                else if (Value.ContainsKey(RESULT_KEY))
                    Value.Remove(RESULT_KEY);
            }
        }

        public GiftinsErrorResponse Error
        {
            get => Value.ContainsKey(ERROR_KEY) ? Value[ERROR_KEY] as GiftinsErrorResponse : null;
            protected set
            {
                if (value != null)
                    Value[ERROR_KEY] = value;
                else
                    Value[ERROR_KEY] = GiftinsErrorResponse.Unknown();
            }
        }

        public GJsonResult(GiftinsErrorResponse error) : base(new Dictionary<string, object>())
        {
            Error = error ?? throw new ArgumentNullException(nameof(error));
            Response = RESPONSE_FAIL;
        }
        public GJsonResult(object value) : base(new Dictionary<string, object>())
        {
            Response = RESPONSE_OK;
            if (value != null)
                Result = value;
        }

        public static implicit operator GJsonResult(GRequestResult result)
        {
            if (result.Succeeded)
                return new GJsonResult(result.Result);
            else
                return new GJsonResult(result.Error);
        }

        public static implicit operator GJsonResult(GActionResult actionResult)
        {
            if (actionResult.Succeeded)
                return new GJsonResult(null as object);
            else
                return new GJsonResult(actionResult.Error);
        }
    }
}
