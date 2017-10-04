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
    public class GeoZonesPage : InternalPage
    {
        public GeoZonesPage(PageManager pages) : base(pages)
        {
        }


        [FindsBy(How = How.XPath, Using = "//table[@class='dataTable']//td[3]/a")]
        public IList<IWebElement> ListOfGeoZones;

        [FindsBy(How = How.XPath, Using = "//table[@id='table-zones']//td[3]/select")]
        public IList<IWebElement> ListOfZonesForGeoZone;

        
        public IWebElement Zone(IWebElement webElement)
        {
            return webElement.FindElement(By.XPath("./option[@selected='selected']"));
        }
    }
}