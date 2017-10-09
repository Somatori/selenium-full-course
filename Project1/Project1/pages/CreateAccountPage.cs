using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace litecart
{
    public class CreateAccountPage : AnyPage
    {
        public CreateAccountPage(PageManager pages) : base(pages)
        {
        }


        [FindsBy(How = How.Name, Using = "firstname")]
        public IWebElement FirstNameField;

        [FindsBy(How = How.Name, Using = "lastname")]
        public IWebElement LastNameField;

        [FindsBy(How = How.Name, Using = "address1")]
        public IWebElement Address1Field;

        [FindsBy(How = How.Name, Using = "postcode")]
        public IWebElement PostcodeField;

        [FindsBy(How = How.Name, Using = "city")]
        public IWebElement CityField;

        [FindsBy(How = How.Name, Using = "country_code")]
        public IWebElement CountryField;

        [FindsBy(How = How.Name, Using = "zone_code")]
        public IWebElement StateField;

        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement EmailField;

        [FindsBy(How = How.Name, Using = "phone")]
        public IWebElement PhoneField;

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement PasswordField;

        [FindsBy(How = How.Name, Using = "confirmed_password")]
        public IWebElement ConfirmPasswordField;

        [FindsBy(How = How.Name, Using = "create_account")]
        public IWebElement CreateAccountButton;
    }
}