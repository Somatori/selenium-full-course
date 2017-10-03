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
    public class Login : TestBase
    {
        [Test]
        public void Login_LoginWithValidCredentials()
        {
            // prepare
            app.Auth.Logout();

            // action
            AccountData account = new AccountData("admin", "admin");
            app.Auth.Login(account);

            // verification      
            //app.Auth.WaitForElement(app.Pages.Internal.UserDropdownMenu);
            //Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }
    }
}
