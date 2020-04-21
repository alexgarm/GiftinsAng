using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Giftins.Core.Domain.User
{
    /// <summary>
    /// Отношение дружбы между пользователями
    /// </summary>
    [DebuggerDisplay("{UserA.ShortName} -> {UserB.ShortName}: {State.ToString(\"F\")}")]
    public class FriendsRelation
    {
        private UserRelationState _state;

        public string Id_UserA { get; protected set; }
        public string Id_UserB { get; protected set; }

        public UserRelationState State
        {
            get => _state;
            set
            {
                _state = value;
                SetUtc = DateTime.UtcNow;
            }
        }
        public DateTime SetUtc { get; protected set; }

        /// <summary>
        /// Entity Framework
        /// </summary>
        protected FriendsRelation() { }
        /// <summary>
        /// <![CDATA[Create relation where Id_UserA compare Id_UserB < 0]]>
        /// </summary>
        /// <param name="userA">Friend A</param>
        /// <param name="target">Friend B</param>
        public FriendsRelation(GiftinsUser user, GiftinsUser target)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (target == null) throw new ArgumentNullException(nameof(target));
            if (user.Id == target.Id) throw new ArgumentException("Unable to create friends relation with yourself");

            // If compare values before making request then search Id can be defined
            // e.g. ".Where(r => r.Id_UserB == id).Select(r => r.Id_UserA)" instead 
            // ".Where(r => r.Id_UserA == id || r.Id_UserB == id)" and then selecting with comparison
            // ON INSERT UPDATE will always target same pair
            if (string.Compare(user.Id, target.Id) < 0)
            {
                Id_UserA = user.Id;
                Id_UserB = target.Id;
                State = UserRelationState.ARequest;
            }
            else
            {
                Id_UserA = target.Id;
                Id_UserB = user.Id;
                State = UserRelationState.BRequest;
            }
        }
    }
}
