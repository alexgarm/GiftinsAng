using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Core.Domain.User
{
    public class Wish
    {
        public string Id { get; protected set; }
        public string UserId { get; protected set; }

        /// <summary>
        /// EF
        /// </summary>
        protected Wish()
        { }

        public Wish(string userId)
        {
            UserId = userId ?? throw new ArgumentNullException(nameof(userId));
        }
    }
}
