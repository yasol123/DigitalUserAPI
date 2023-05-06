using System;
using System.Collections.Generic;
using System.Text;

namespace Yasol.DigitalUser.Model.Account
{
    public class UserAccount
    {
        public string ADB2CId { get; set; }
        public string UserName { get; set; }
        public string PWDK { get; set; }
        public string RegisteredDate { get; set; }
        public AccountType UserType { get; set; } 
        public Profile UserProfile { get; set; }
    }

    public enum AccountType
    {
        User = 1,
        Admin = 2
    }
    public class Profile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Contact ContactInformation { get; set; }
        public Address UserAddress { get; set; }
    }
    public class Address
    {
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }
    public class Contact
    {
        public ContactType Type{ get;set; }
        public string ContactValue { get; set; }
        public string Description { get; set; }
    }
    public enum ContactType
    {
        Email = 1,
        Phone = 2,
        Other = 3
    }
}
