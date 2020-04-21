using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Newtonsoft.Json;

namespace Giftins.Core.Domain.User
{

    [DebuggerDisplay("[{UserId}] {string.Join(\" \", new[] { LastName, FirstName })}")]
    public class UserProfile
    {
        #region Property names
        public const string ID_PROP = "id";
        public const string FIRST_NAME_PROP = "first_name";
        public const string LAST_NAME_PROP = "last_name";
        public const string BIRTHDATE_PROP = "birthdate";
        public const string GENDER_PROP = "gender";
        public const string RELATION_PROP = "relation";
        public const string CITY_PROP = "city";
        public const string COUNTRY_PROP = "country";
        public const string BIRTHDATE_DISPLAY_PROP = "birthdate_display";
        public const string RELATION_DISPLAY_PROP = "relation_display";
        #endregion

        [JsonProperty(PropertyName = ID_PROP)]
        public string UserId { get; protected set; }

        [JsonProperty(PropertyName = FIRST_NAME_PROP)]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = LAST_NAME_PROP)]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = BIRTHDATE_PROP)]
        public DateTime? Birthdate { get; set; } = null;

        public int? GenderId { get; set; } = Gender.Undefined;
        public int? RelationId { get; set; } = Relation.Undefined;

        [JsonProperty(PropertyName = GENDER_PROP)]
        public Gender Gender => Gender.Parse(GenderId);

        [JsonProperty(PropertyName = RELATION_PROP)]
        public Relation Relation => Relation.Parse(RelationId);

        public string PictureId { get; set; }

        [JsonProperty(PropertyName = CITY_PROP)]
        public string City { get; set; }

        [JsonProperty(PropertyName = COUNTRY_PROP)]
        public string Country { get; set; }

        #region Privacy

        public int RelationDisplayPolicyId { get; set; } = PrivacyPolicy.OnlyMe;
        public int BirthDisplayPolicyId { get; set; } = PrivacyPolicy.OnlyMe;

        [JsonProperty(PropertyName = RELATION_DISPLAY_PROP)]
        public PrivacyPolicy RelationDisplayPolicy => PrivacyPolicy.Parse(RelationDisplayPolicyId);
        [JsonProperty(PropertyName = BIRTHDATE_DISPLAY_PROP)]
        public PrivacyPolicy BirthDisplayPolicy => PrivacyPolicy.Parse(BirthDisplayPolicyId);

        #endregion

        /// <summary>
        /// EF
        /// </summary>
        protected UserProfile()
        { }

        public UserProfile(string userId)
        {
            UserId = userId ?? throw new ArgumentNullException(nameof(userId));
        }
    }
}
