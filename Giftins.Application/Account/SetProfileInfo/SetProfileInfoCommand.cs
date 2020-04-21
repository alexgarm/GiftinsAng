using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Giftins.Application.Account.SetProfileInfo
{
    public class SetProfileInfoCommand : IRequest
    {
        private IDictionary<string, string> _newProperties;

        /// <summary>
        /// Id of user that initiates operation
        /// </summary>
        public string InitiatorId { get; set; }

        /// <summary>
        /// Id of user account to change properties
        /// </summary>
        public string AccountId { get; set; }
        
        /// <summary>
        /// List of new values for properties
        /// </summary>
        public IEnumerable<KeyValuePair<string, string>> NewProperties
        {
            get => _newProperties ?? (_newProperties = new Dictionary<string, string>());
            set => _newProperties = new Dictionary<string, string>(value);
        }
    }
}
