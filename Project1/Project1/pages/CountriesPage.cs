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
    public class CountriesPage : InternalPage
    {
        public CountriesPage(PageManager pages) : base(pages)
        {
        }


        [FindsBy(How = How.XPath, Using = "//tr[@class='row']")]
        public IList<IWebElement> ListOfCountries;

        [FindsBy(How = How.XPath, Using = "//tr[@class='row']/td[5]/a")]
        public IList<IWebElement> ListOfCountryNames;

        [FindsBy(How = How.XPath, Using = "//tr[@class='row']/td[6]")]
        public IList<IWebElement> ListOfAmountOfCountryZones;

        [FindsBy(How = How.XPath, Using = "//tr[@class='row']/td[5]/a")]
        public IList<IWebElement> ListOfCountryZoneNames;


        //public IWebElement ContactInGrid(ContactData contact)
        //{
        //    By locator = By.XPath("//td[@class='email']/span[text()='" + contact.Email + "']");
        //    return WaitForElement(locator);
        //}
    }
}