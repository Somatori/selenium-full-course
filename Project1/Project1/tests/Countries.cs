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
    public class Countries : AuthTestBase
    {
        [Test]
        public void Countries_Sorting()
        {
            // prepare
            app.Navigator.GoToCountriesPage();

            // action
            List<string> ListOfCoutriesAsIs = new List<string>();
            List<string> ListOfCoutriesWithSorting = new List<string>();

            foreach (IWebElement webElement in app.Pages.Countries.ListOfCountryNames)
            {
                ListOfCoutriesAsIs.Add(webElement.GetAttribute("textContent"));
                ListOfCoutriesWithSorting.Add(webElement.GetAttribute("textContent"));
            }

            ListOfCoutriesWithSorting.Sort();

            // verification
            Assert.AreEqual(ListOfCoutriesAsIs, ListOfCoutriesWithSorting);
        }

        [Test]
        public void CountryZones_Sorting()
        {
            // prepare
            app.Navigator.GoToCountriesPage();

            // action
            foreach (IWebElement webElement in app.Pages.Countries.ListOfCountries)
            {
                app.Navigator.GoToCountriesPage();

                IWebElement zones = webElement.FindElement(By.XPath(".//td[6]"));
                int amount = Convert.ToInt32(zones.Text);
                if (amount > 0)
                {
                    webElement.FindElement(By.XPath(".//td[5]/a")).Click();
                    IList<IWebElement> ListOfCountryZoneNames = app.Pages.Countries.ListOfCountryZoneNames;
                    List<string> ListOfCoutryZonesAsIs = new List<string>();
                    List<string> ListOfCoutryZonesWithSorting = new List<string>();

                    for (int i = 0; i < amount; i++)
                    {
                        ListOfCoutryZonesAsIs.Add(ListOfCountryZoneNames[i].GetAttribute("textContent"));
                        ListOfCoutryZonesWithSorting.Add(ListOfCountryZoneNames[i].GetAttribute("textContent"));
                    }

                    ListOfCoutryZonesWithSorting.Sort();

                    // verification
                    Assert.AreEqual(ListOfCoutryZonesAsIs, ListOfCoutryZonesWithSorting);

                    //foreach (IWebElement webElement2 in app.Pages.Countries.ListOfCountryZoneNames)
                    //{
                    //    ListOfCoutryZonesAsIs.Add(webElement2.GetAttribute("textContent"));
                    //    ListOfCoutryZonesWithSorting.Add(webElement2.GetAttribute("textContent"));
                    //}


                }


            }
        }
    }
}
