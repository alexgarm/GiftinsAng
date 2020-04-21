using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Giftins.Core.ComponentModel;

namespace Giftins.Core.Domain.User
{
    public sealed class Relation : ClassEnumeration<Relation>
    {
        public const string UNDEFINED_NAME = "undefined";
        public const string SINGLE_NAME = "single";
        public const string HAVE_PARTHNER_NAME = "have_parthner";
        public const string ENGAGED_NAME = "engaged";
        public const string MARRIED_NAME = "married";
        public const string CIVIL_MARRIAGE_NAME = "civil";

        public static readonly Relation Undefined = new Relation(0, UNDEFINED_NAME);
        public static readonly Relation Single = new Relation(1, SINGLE_NAME);
        public static readonly Relation HaveParthner = new Relation(2, HAVE_PARTHNER_NAME);
        public static readonly Relation Engaged = new Relation(3, ENGAGED_NAME);
        public static readonly Relation Married = new Relation(4, MARRIED_NAME);
        public static readonly Relation CivilMarriage = new Relation(5, CIVIL_MARRIAGE_NAME);

        private Relation(int id, string name) 
            : base(id, name)
        { }

        public static Relation Parse(int? id) => Parse(id, Undefined);
        public static new Relation Parse(string value) => Parse(value, Undefined);
    }
}
