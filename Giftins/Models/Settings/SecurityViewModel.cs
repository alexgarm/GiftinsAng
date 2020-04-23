using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giftins.Web.Models.Settings
{
    public class SecurityViewModel
    {
        private IEnumerable<string> _phones;
        private IEnumerable<object> _blacklist;

        public bool HasPassword { get; set; }

        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordConfirmation { get; set; }

        public IEnumerable<string> Phones
        {
            get => _phones ?? (_phones = new List<string>());
            set => _phones = value;
        }

        public IEnumerable<object> Blacklist
        {
            get => _blacklist ?? (_blacklist = new List<object>());
            set => _blacklist = value;
        }
    }
}
