using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Core.Domain.Basket
{
    public partial class BasketItem
    {
        public string Id { get; protected set; }
        /// <summary>
        /// Basket item user id
        /// </summary>
        public string Id_User { get; protected set; }

        public DateTime AddedUtc { get; protected set; }

        public int Quantity { get; set; }

        public bool Archieved { get; set; }

        /// <summary>
        /// Entity Framework
        /// </summary>
        protected BasketItem() { }
        public BasketItem(string userId, int quantity)
        {
            Id_User = userId ?? throw new ArgumentNullException(nameof(userId));

            Quantity = quantity;
            Archieved = false;

            AddedUtc = DateTime.UtcNow;
        }
    }
}
