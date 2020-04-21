using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Core.Domain.Market
{
    /// <summary>
    /// Владелец торговых площадок
    /// </summary>
    public class Vendor
    {
        public string Id { get; protected set; }
        public string UserId { get; protected set; }

        public string Name { get; set; }

        /// <summary>
        /// Enfity Framework
        /// </summary>
        protected Vendor()
        { }
        public Vendor(string userId, string name)
        {
            UserId = userId;
            Name = name;
        }

        public void ChangeOwner(string newUserId)
        {
            UserId = newUserId;
        }
    }
}
