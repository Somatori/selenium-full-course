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
    public class LoginPage : AnyPage
    {
        public LoginPage(PageManager pages) : base(pages)
        {
        }


        [FindsBy(How = How.Name, Using = "username")]
        public IWebElement UsernameField;

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement PasswordField;

        [FindsBy(How = How.Name, Using = "login")]
        public IWebElement SubmitButton;
    }
}