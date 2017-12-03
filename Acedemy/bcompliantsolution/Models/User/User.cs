using System;
namespace Models.User
{
    public class User : BaseEntity
    {
        public User()
        {

        }

        //Authentication Details
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        //Personal Details
        public string IdCardNumber { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public ushort PhoneCountryCode { get; set; }
        public int PhoneNumber { get; set; }

        public long? AddressId { get; set; }
        //public Address Address { get; set; }

        public ushort MobileCountryCode { get; set; }
        public int MobileNumber { get; set; }

        public string VatNumber { get; set; }

        public bool AreYouAMember { get; set; }

        //Declaration Fiekds
        public bool TermsAndConditions { get; set; }
        public bool DataProtectionAct { get; set; }

        //Audit Fields
        public DateTime DateCreated { get; set; }
    }
}
