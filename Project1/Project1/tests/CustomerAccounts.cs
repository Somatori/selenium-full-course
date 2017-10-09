using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace litecart
{
    [TestFixture]
    public class CustomerAccounts : TestBase
    {
        [Test]
        public void Accounts_NewAccountRegistration()
        {
            // prepare
            
            string timeStamp = app.Customer.GetTimestamp(DateTime.Now);

            CustomerAccountData account = new CustomerAccountData("email-" + timeStamp + "@qa.test", "customer")
            {
                FirstName = "John",
                LastName = "Johnson",
                Address1 = "500 West Broadway",
                Postcode = "92101",
                City = "San Diego",
                State = "California",
                Country = "United States",
                Phone = "+18883407255"
            };

            // action
            app.Customer.CreateAccount(account);
            app.Customer.Logout();
            app.Customer.Login(account);
            app.Customer.Logout();
        }
    }
}
