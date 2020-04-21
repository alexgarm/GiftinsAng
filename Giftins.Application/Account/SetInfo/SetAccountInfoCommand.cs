using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Giftins.Application.Account.SetInfo
{
    public class SetAccountInfoCommand : IRequest
    {
        private IEnumerable<KeyValuePair<string, string>> _values;

        /// <summary>
        /// Id of user that invoke operaion
        /// </summary>
        public string InitiatorId { get; set; }
        
        /// <summary>
        /// Id of user account
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// New values
        /// </summary>
        public IEnumerable<KeyValuePair<string, string>> Values
        {
            get => _values ?? (_values = Array.Empty<KeyValuePair<string, string>>());
            set => _values = new Dictionary<string, string>(value);
        }
    }
}
