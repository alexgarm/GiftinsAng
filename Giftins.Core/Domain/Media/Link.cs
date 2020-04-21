using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Core.Domain.Media
{
    /// <summary>
    /// Local link pointing to external resource
    /// </summary>
    public partial class Link
    {
        /// <summary>
        /// Local short link code
        /// </summary>
        public string LocalUrl { get; set; }
        /// <summary>
        /// Resource Uri
        /// </summary>
        public string ExternalUrl { get; set; }

        /// <summary>
        /// Link alias
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Link display caption
        /// </summary>
        public string Caption { get => string.IsNullOrEmpty(Alias) ? ExternalUrl : Alias; }

        /// <summary>
        /// Link display description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Link preview image
        /// </summary>
        public string PreviewImage { get; set; }
    }
}
