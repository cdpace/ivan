﻿using System;
namespace Models.User
{
    public class Address : BaseEntity
    {
        public Address()
        {
        }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
    }
}
