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

        [FindsBy(How = How.XPath, Using = "//table[@id='table-zones']//td[3]")]
        public IList<IWebElement> ListOfCountryZoneNames;

        [FindsBy(How = How.CssSelector, Using = "a.button")]
        public IWebElement AddNewCountryButton;


        public IWebElement ZonesValueForCountry(IWebElement webElement)
        {
            return webElement.FindElement(By.XPath(".//td[6]"));
        }

        public IWebElement Country(IWebElement webElement)
        {
            return webElement.FindElement(By.XPath(".//td[5]/a"));
        }
    }
}