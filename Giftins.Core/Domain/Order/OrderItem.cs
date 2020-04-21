using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Core.Domain.Order
{
    public class OrderItem
    {
        public long OrderId { get; protected set; }

        /// <summary>
        /// Entity Framework
        /// </summary>
        protected OrderItem() { }

        public OrderItem(long orderId)
        {
            OrderId = orderId;
        }
    }
}
