using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Giftins.Core.ComponentModel;

namespace Giftins.Core.Domain.User
{
    public sealed class Gender : ClassEnumeration<Gender>
    {
        public const string UNDEFINED_NAME = "undefined";
        public const string MALE_NAME = "male";
        public const string FEMALE_NAME = "female";

        public static readonly Gender Undefined = new Gender(0, UNDEFINED_NAME);
        public static readonly Gender Male = new Gender(1, MALE_NAME);
        public static readonly Gender Female = new Gender(2, FEMALE_NAME);
        
        private Gender(int id, string name) 
            : base(id, name)
        { }

        public static IEnumerable<Gender> Binary { get; } = new[] { Male, Female };

        public static Gender Parse(int? id) => Parse(id, Undefined);
        public static new Gender Parse(string value) => Parse(value, Undefined);
    }
}
