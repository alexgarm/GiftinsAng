using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Core.Domain.Market
{
    public class MarketProductCategory
    {
        public string MarketCategoryId { get; set; }
        public string MarketProductId { get; set; }

        /// <summary>
        /// Entity Framework
        /// </summary>
        protected MarketProductCategory() { }

        public MarketProductCategory(MarketCategory category, MarketProduct product)
        {
            Category = category ?? throw new ArgumentNullException(nameof(category));
            Product = product ?? throw new ArgumentNullException(nameof(product));

            MarketCategoryId = category.Id;
            MarketProductId = product.Id;
        }

        public virtual MarketCategory Category { get; protected set; }
        public virtual MarketProduct Product { get; protected set; }
    }
}
