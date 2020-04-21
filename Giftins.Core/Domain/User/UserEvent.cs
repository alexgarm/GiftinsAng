using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Core.Domain.User
{
    public class UserEvent
    {
        public string Id { get; protected set; }
        public string Id_User { get; protected set; }

        public GiftinsEventType Type { get; set; }

        /// <summary>
        /// Entity Framework
        /// </summary>
        protected UserEvent() { }
    }
}
