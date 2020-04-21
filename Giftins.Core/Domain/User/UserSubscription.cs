using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Core.Domain.User
{
    public partial class UserSubscription
    {
        public string Id { get; protected set; }
        public string Id_User { get; protected set; }
        public string Id_Target { get; protected set; }

        public bool Birthday { get; set; } = true;
        public bool Important { get; set; } = true;
        public bool Personal { get; set; } = true;
        public bool Family { get; set; } = true;
        public bool Friends { get; set; } = true;
        public bool Other { get; set; } = true;


        /// <summary>
        /// Entity Framework
        /// </summary>
        protected UserSubscription() { }
        public UserSubscription(GiftinsUser user, GiftinsUser target)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            Target = target ?? throw new ArgumentNullException(nameof(target));

            Id_User = user.Id;
            Id_Target = target.Id;
        }

        #region Navigation Properties

        public virtual GiftinsUser User { get; protected set; }
        public virtual GiftinsUser Target { get; protected set; }

        #endregion
    }
}
