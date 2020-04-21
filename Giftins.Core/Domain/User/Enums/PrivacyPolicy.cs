using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Giftins.Core.ComponentModel;

namespace Giftins.Core.Domain.User
{
    public sealed class PrivacyPolicy : ClassEnumeration<PrivacyPolicy>
    {
        public const string ONLY_ME_NAME = "me";
        public const string FRIENDS_NAME = "friends";
        public const string FRIENDS_OF_FRIENDS_NAME = "friends_of_friends";
        public const string ANYONE_NAME = "anyone";

        public static readonly PrivacyPolicy OnlyMe = new PrivacyPolicy(0, ONLY_ME_NAME);
        public static readonly PrivacyPolicy Friends = new PrivacyPolicy(1, FRIENDS_NAME);
        public static readonly PrivacyPolicy FriendsOfFriends = new PrivacyPolicy(2, FRIENDS_OF_FRIENDS_NAME);
        public static readonly PrivacyPolicy Anyone = new PrivacyPolicy(3, ANYONE_NAME);

        private PrivacyPolicy(int id, string name) 
            : base(id, name)
        { }

        public static PrivacyPolicy Parse(int? id) => Parse(id, OnlyMe);
        public static new PrivacyPolicy Parse(string value) => Parse(value, OnlyMe);
    }
}
