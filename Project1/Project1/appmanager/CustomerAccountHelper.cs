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
    public class CustomerAccountHelper : HelperBase
    {
        private PageManager pages;

        public CustomerAccountHelper(ApplicationManager manager) : base(manager)
        {
            this.pages = manager.Pages;
        }

        
        public CustomerAccountHelper CreateAccount(CustomerAccountData account)
        {
            manager.Navigator.GoToCreateAccountPage();

            Type(pages.Registration.FirstNameField, account.FirstName);
            Type(pages.Registration.LastNameField, account.LastName);
            Type(pages.Registration.Address1Field, account.Address1);
            Type(pages.Registration.PostcodeField, account.Postcode);
            Type(pages.Registration.CityField, account.City);

            // country
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            IWebElement сountryField = pages.Registration.CountryField;            
            js.ExecuteScript("arguments[0].selectedIndex = 224; arguments[0].dispatchEvent(new Event('change'))", 
                сountryField);

            Type(pages.Registration.EmailField, account.EmailAddress);
            Type(pages.Registration.PhoneField, account.Phone);
            Type(pages.Registration.PasswordField, account.Password);
            Type(pages.Registration.ConfirmPasswordField, account.Password);

            pages.Registration.CreateAccountButton.Click();

            return this;
        }

        public void Logout()
        {
            WaitForElement(pages.Main.LogoutLink).Click();
        }

        public void Login(CustomerAccountData account)
        {
            manager.Navigator.GoToMainPage();
            Type(pages.Main.EmailAddresFieldInLoginSection, account.EmailAddress);
            Type(pages.Main.PasswordFieldInLoginSection, account.Password);
            pages.Main.LoginButtonInLoginSection.Click();
        }
    }
}
