using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace Giftins.Core.Domain.User
{
    [DebuggerDisplay("{Country}. {StateProvinceId} ({Region}). {Street} {Building} ({PostCode})")]
    [DisplayName("Address")]
    [Description("Address information")]
    public class UserAddress
    {
        public string Id { get; protected set; }
        public string UserId { get; protected set; }

        /// <summary>
        /// ID of country
        /// </summary>
        public string CountryCode { get; set; }
        /// <summary>
        /// State / Province / Prefecture / County
        /// </summary>
        public string StateProvinceId { get; set; }

        /// <summary>
        /// City / Town / Village
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Street / Road / Block
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// Building Name / Number
        /// </summary>
        public string Building { get; set; }

        /// <summary>
        /// Post / Zip Code
        /// </summary>
        public string PostCode { get; set; }

        /// <summary>
        /// EF
        /// </summary>
        protected UserAddress()
        { }

        public UserAddress(string userId, string countryCode, string stateProvinceId, string city, string postCode, string street, string building)
        {
            UserId = userId ?? throw new ArgumentNullException(nameof(userId));

            CountryCode = countryCode;
            StateProvinceId = stateProvinceId;

            City = city;
            Street = street;
            Building = building;
            PostCode = postCode;
        }
    }
}
