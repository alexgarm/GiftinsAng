using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Core.Domain.Directory
{
    /// <summary>
    /// Represents a country
    /// </summary>
    public class Country
    {
        public int Id { get; protected set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the two letter ISO code
        /// </summary>
        public string TwoLetterIsoCode { get; set; }

        /// <summary>
        /// Gets or sets the three letter ISO code
        /// </summary>
        public string ThreeLetterIsoCode { get; set; }

        /// <summary>
        /// Gets or sets the numeric ISO code
        /// </summary>
        public int NumericIsoCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether billing is allowed to this country
        /// </summary>
        public bool AllowsBilling { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether shipping is allowed to this country
        /// </summary>
        public bool AllowsShipping { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether customers in this country must be charged EU VAT
        /// </summary>
        public bool SubjectToVat { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether the entity is published
        /// </summary>
        public bool Published { get; set; } = false;

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }
        
        protected Country()
        { }

        /// <summary>
        /// Creates entity for country
        /// </summary>
        /// <param name="name">Country name</param>
        /// <param name="code2L">Two letter ISO code</param>
        /// <param name="code3L">Three letter ISO code</param>
        /// <param name="code">Numeric ISO code</param>
        public Country(string name, string code2L, string code3L, int code)
        {
            Name = name;
            TwoLetterIsoCode = code2L;
            ThreeLetterIsoCode = code3L;
            NumericIsoCode = code;
        }
    }
}
