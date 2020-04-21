using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Core.Domain.Product
{
    public class CrossSellProduct
    {
        public string ProductIdA { get; protected set; }

        public string ProductIdB { get; protected set; }

        #region Navigation properties

        public virtual Product ProductA { get; protected set; }
        public virtual Product ProductB { get; protected set; }

        #endregion
    }
}
