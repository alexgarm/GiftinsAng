using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Core.Domain.Order
{
    public class Order
    {
        private ICollection<OrderItem> _items;

        public long Id { get; protected set; }
        public string UserId { get; protected set; }

        public DateTime CreatedUtc { get; set; }

        /// <summary>
        /// Entity Framework
        /// </summary>
        protected Order() { }

        #region Navigation properties
        
        public virtual ICollection<OrderItem> Items
        {
            get => _items ?? (_items = new List<OrderItem>());
            protected set => _items = value;
        }

        #endregion
    }
}
