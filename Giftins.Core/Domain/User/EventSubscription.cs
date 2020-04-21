using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Core.Domain.User
{
    public class EventSubscription
    {
        public string Id_User { get; protected set; }
        public string Id_Event { get; protected set; }

        public bool Subscribe { get; set; }

        /// <summary>
        /// Entity Framework
        /// </summary>
        protected EventSubscription() { }
    }
}
