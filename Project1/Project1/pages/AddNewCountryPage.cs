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
    public class CountriesPage_AddNewCountry : InternalPage
    {
        public CountriesPage_AddNewCountry(PageManager pages) : base(pages)
        {
        }


        [FindsBy(How = How.CssSelector, Using = "i.fa.fa-external-link")]
        public IList<IWebElement> ExternalLinks;

        //[FindsBy(How = How.XPath, Using = "a.button")]
        //public IWebElement AddNewCountryButton;
    }
}