using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace litecart
{
    public class LoginHelper : HelperBase
    {
        private PageManager pages;

        public LoginHelper(ApplicationManager manager) : base(manager)
        {
            this.pages = manager.Pages;
        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                return;

                //if (IsLoggedIn(account))
                //{
                //    return;
                //}
                //Logout();
            }
            
            manager.Navigator.GoToLoginPage();

            Type(pages.Login.UsernameField, account.Username);
            Type(pages.Login.PasswordField, account.Password);
            pages.Login.SubmitButton.Click();

            WaitForElement(pages.Internal.LogoutLink);
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(pages.Internal.LogoutLink);
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn();
                //&& GetLoggedUserName() == account.Username;
        }

        //public string GetLoggedUserName()
        //{
        //    //string text = pages.Internal.UserTitleInDropdownMenu.Text;
        //    /return text;
        //}

        public void Logout()
        {
            if (IsLoggedIn())
            {
                pages.Internal.LogoutLink.Click();
            }            
        }
    }
}
