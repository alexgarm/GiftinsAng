using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Core.Domain.Market
{
    /// <summary>
    /// Торговая площадка
    /// </summary>
    public class Marketplace
    {
        public string Id { get; protected set; }
        public string VendorId { get; protected set; }
        public string PictureId { get; protected set; }

        public string Name { get; set; }

        public string Url { get; set; }
        
        public bool Deactivated { get; set; }

        /// <summary>
        /// Entity Framework
        /// </summary>
        protected Marketplace()
        { }
        public Marketplace(Vendor vendor, string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            VendorId = vendor.UserId;
            Name = name;
        }
    }
}
