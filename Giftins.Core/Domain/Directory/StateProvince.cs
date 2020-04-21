using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Core.Domain.Directory
{
    /// <summary>
    /// Represents a state/province
    /// </summary>
    public class StateProvince
    {
        public int Id { get; protected set; }
        /// <summary>
        /// Gets or sets the country identifier
        /// </summary>
        public int CountryId { get; protected set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the abbreviation
        /// </summary>
        public string Abbreviation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is published
        /// </summary>
        public bool Published { get; set; } = false;

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; } = 0;

        protected StateProvince()
        { }

        public StateProvince(int countryId, string name, string abbr)
        {
            CountryId = countryId;
            Name = name;
            Abbreviation = abbr;
        }
    }
}
