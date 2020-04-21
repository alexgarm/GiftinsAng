using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Core.Domain.User
{
    /// <summary>
    /// Тип события
    /// </summary>
    public enum GiftinsEventType
    {
        Birthday = 0,
        Important = 1,
        Personal = 2,
        Family = 3,
        Friends = 4,
        Other = 5
    }
}
