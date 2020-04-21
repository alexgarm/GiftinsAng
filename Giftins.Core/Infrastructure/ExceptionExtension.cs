using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins
{
    public static class ExceptionExtension
    {
        public static string DeepExceptionMessage(this Exception ex)
        {
            return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
        }
    }
}
