using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Core.Domain.User
{
    public enum UserRelationState
    {
        /// <summary>
        /// Пользователь A выслал заявку пользователю B
        /// </summary>
        ARequest = 11,
        /// <summary>
        /// Пользователь B выслал заявку пользователю A
        /// </summary>
        BRequest = 12,
        /// <summary>
        /// Пользователь B отклонил заявку пользователя А
        /// </summary>
        BReject = 21,
        /// <summary>
        /// Пользователь A отклонил заявку пользователя B
        /// </summary>
        AReject = 22,
        /// <summary>
        /// Пользователь A заблокировал пользователя B
        /// </summary>
        ABlock = 31,
        /// <summary>
        /// Пользователь B заблокировал пользователя A
        /// </summary>
        BAlock = 32,
        /// <summary>
        /// Пользователи в состоянии взаимной дружбы
        /// </summary>
        Friends = 0,
        /// <summary>
        /// Пользователи в состоянии взаимной блокировки
        /// </summary>
        Blocked = 1
    }
}
