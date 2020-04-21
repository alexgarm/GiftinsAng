using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Core.Domain.Product
{
    /// <summary>
    /// Represents a manufacturer
    /// </summary>
    public class Manufacturer
    {
        public string Id { get; protected set; }
        
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the meta keywords
        /// </summary>
        public string MetaKeywords { get; set; }

        /// <summary>
        /// Gets or sets the meta description
        /// </summary>
        public string MetaDescription { get; set; }

        /// <summary>
        /// Gets or sets the meta title
        /// </summary>
        public string MetaTitle { get; set; }
    }
}
