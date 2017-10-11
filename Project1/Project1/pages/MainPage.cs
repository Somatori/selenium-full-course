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
    public class MainPage : AnyPage
    {
        public MainPage(PageManager pages) : base(pages)
        {
        }


        [FindsBy(How = How.XPath, Using = "//div[@id='box-campaigns']//li/a[1]")]
        public IWebElement TheFirstItemInCampaingsSection;

        [FindsBy(How = How.LinkText, Using = "Logout")]
        public IWebElement LogoutLink;

        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement EmailAddresFieldInLoginSection;

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement PasswordFieldInLoginSection;

        [FindsBy(How = How.Name, Using = "login")]
        public IWebElement LoginButtonInLoginSection;

        [FindsBy(How = How.XPath, Using = "(//div[@id='box-most-popular']//li/a[1])[1]")]
        public IWebElement TheFirstItemInMostPopularSection;


        public IWebElement ItemName(IWebElement webElement)
        {
            return webElement.FindElement(By.XPath("./div[2]"));
        }

        public IWebElement ItemRegularPrice(IWebElement webElement)
        {
            return webElement.FindElement(By.XPath(".//s[@class='regular-price']"));
        }

        public IWebElement ItemCampaignPrice(IWebElement webElement)
        {
            return webElement.FindElement(By.XPath(".//strong[@class='campaign-price']"));
        }
    }
}