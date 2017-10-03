using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace litecart
{
    public class ContactData
    {
        public ContactData()
        {
        }

        public ContactData(string email, string firstName)
        {
            Email = email;
            FirstName = firstName;
        }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

    }
}
