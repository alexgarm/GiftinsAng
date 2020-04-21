using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Core.Domain.Market
{
    public class MarketCategory
    {
        public string Id { get; protected set; }
        public string MarketId { get; protected set; }

        public string ParentCategoryId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public bool Publish { get; set; }

        public virtual MarketCategory ParentCategory { get; set; }
    }
}
