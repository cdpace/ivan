using System;
using Models.User;

namespace Models.Events
{
    public class BillingDetails : BaseEntity
    {
        public long UserId { get; set; }
        public string FriendlyName { get; set; }
        public Address Address { get; set; }
        public string VAT { get; set; }
    }
}
