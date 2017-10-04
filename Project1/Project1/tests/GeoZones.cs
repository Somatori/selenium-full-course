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
    public class GeoZones : AuthTestBase
    {
        [Test]
        public void GeoZones_Sorting()
        {
            // prepare
            app.Navigator.GoToGeoZonesPage();

            // action
            List<string> ListOfUrlsToGo = new List<string>();

            foreach (IWebElement webElement in app.Pages.GeoZones.ListOfGeoZones)
            {
                ListOfUrlsToGo.Add(webElement.GetAttribute("href"));
            }

            foreach (string url in ListOfUrlsToGo)
            {
                app.Navigator.GoToPage(url);

                List<string> ListOfZonesAsIs = new List<string>();
                List<string> ListOfZonesWithSorting = new List<string>();

                foreach (IWebElement webElement in app.Pages.GeoZones.ListOfZonesForGeoZone)
                {
                    ListOfZonesAsIs.Add(app.Pages.GeoZones.Zone(webElement).GetAttribute("textContent"));
                    ListOfZonesWithSorting.Add(app.Pages.GeoZones.Zone(webElement).GetAttribute("textContent"));
                }

                ListOfZonesWithSorting.Sort();

                // verification
                Assert.AreEqual(ListOfZonesAsIs, ListOfZonesWithSorting);
            }
        }
    }
}
