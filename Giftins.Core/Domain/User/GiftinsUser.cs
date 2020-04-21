using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;

using Newtonsoft.Json;

namespace Giftins.Core.Domain.User
{
    [DebuggerDisplay("{Id}")]
    public class GiftinsUser : IdentityUser
    {
        #region Property names
        public const string ID_PROP = "id";
        public const string EMAIL_PROP = "email";
        public const string EMAIL_CONFIRMED_PROP = "email_confirmed";
        public const string PHONE_NUMBER_PROP = "phone_number";
        public const string PHONE_NUMBER_CONFIRMED_PROP = "phone_number_confirmed";
        public const string LOCKOUT_ENABLED_PROP = "lockout_enabled";
        public const string LOCKOUT_END_DATE_PROP = "lockout_end";
        public const string ENABLED_PROP = "enabled";
        public const string LANGUAGE_PROP = "language";
        #endregion

        #region IdentityUser
        [JsonProperty(PropertyName = ID_PROP)]
        public override string Id { get => base.Id; set => base.Id = value; }

        [JsonProperty(PropertyName = EMAIL_PROP)]
        public override string Email { get => base.Email; set => base.Email = value; }
        [JsonProperty(PropertyName = EMAIL_CONFIRMED_PROP)]
        public override bool EmailConfirmed { get => base.EmailConfirmed; set => base.EmailConfirmed = value; }

        [JsonProperty(PropertyName = PHONE_NUMBER_PROP)]
        public override string PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }
        [JsonProperty(PropertyName = PHONE_NUMBER_CONFIRMED_PROP)]
        public override bool PhoneNumberConfirmed { get => base.PhoneNumberConfirmed; set => base.PhoneNumberConfirmed = value; }
        #endregion

        [JsonProperty(PropertyName = ENABLED_PROP)]
        public bool Enabled { get; set; } = true;

        [JsonProperty(PropertyName = LANGUAGE_PROP)]
        public string Language { get; set; } = null;

        public GiftinsUser()
            : base()
        { }

        public GiftinsUser(string userName)
            : base(userName)
        { }
    }
}