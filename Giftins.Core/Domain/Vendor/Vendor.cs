using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Core.Domain.Vendor
{
    public class Vendor
    {
        public string Id { get; protected set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Pciture { get; set; }
    }
}
