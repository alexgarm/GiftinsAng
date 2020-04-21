using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Core.Domain.Product
{
    public class ProductTag
    {
        private ICollection<Product> _products;

        public string Name { get; set; }

        public virtual ICollection<Product> Products
        {
            get => _products ?? (_products = new List<Product>());
            set => _products = value;
        }
    }
}
