using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace litecart
{
    public class CustomerAccountData
    {
        //private string emailAddress;
        //private string password;
        

        public CustomerAccountData(string emailAddress, string password)
        {
            EmailAddress = emailAddress;
            Password = password;
        }

        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

    }
}