using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using Giftins.Core.Domain.User;

namespace Giftins.Web.Models.Settings
{
    public class IndexViewModel
    {
        private DateTime? _bdate;

        public string StatusMessage { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public int GenderId { get; set; }
        public Gender Gender => Gender.Parse(GenderId);

        public DateTime? Birthdate
        {
            get => _bdate ?? (_bdate = new DateTime(BirthYear, BirthMonth, BirthDay));
            set => _bdate = value;
        }
        #region BDate
        public int BirthDay
        {
            get => _bdate?.Day ?? 1;
            set => _bdate = new DateTime(BirthYear, BirthMonth, value);
        }
        public int BirthMonth
        {
            get => _bdate?.Month ?? 1;
            set => _bdate = new DateTime(BirthYear, value, BirthDay);
        }
        public int BirthYear
        {
            get => _bdate?.Year ?? 2000;
            set => _bdate = new DateTime(value, BirthMonth, BirthDay);
        }
        #endregion

        public int BirthDisplayPolicyId { get; set; }
        public PrivacyPolicy BirthDisplayPolicy => PrivacyPolicy.Parse(BirthDisplayPolicyId);
    }
}
