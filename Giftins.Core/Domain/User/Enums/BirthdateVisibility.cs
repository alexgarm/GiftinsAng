using System;
using System.Collections.Generic;
using System.Text;
using Giftins.Core.ComponentModel;

namespace Giftins.Core.Domain.User
{
    public sealed class BirthdateVisibility : ClassEnumeration<BirthdateVisibility>
    {
        private const string DISPLAY_NAME = "display";
        private const string HIDE_YEAR_NAME = "hide_year";
        private const string DO_NOT_SHOW_NAME = "do_not_show";

        public static readonly BirthdateVisibility Display = new BirthdateVisibility(0, DISPLAY_NAME);
        public static readonly BirthdateVisibility HideYear = new BirthdateVisibility(1, HIDE_YEAR_NAME);
        public static readonly BirthdateVisibility DontShow = new BirthdateVisibility(2, DO_NOT_SHOW_NAME);

        private BirthdateVisibility(int id, string name)
            : base(id, name)
        { }
    }
}
