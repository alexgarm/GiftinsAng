using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Core.Domain.Product
{
    public class ProductCategory
    {
        public string ProductId { get; protected set; }
        public int CategoryId { get; protected set; }

        /// <summary>
        /// Entity Framework
        /// </summary>
        protected ProductCategory() { }

        #region Navigation Properties

        public virtual Product Product { get; protected set; }
        public virtual Category Category { get; protected set; }

        #endregion
    }
}
