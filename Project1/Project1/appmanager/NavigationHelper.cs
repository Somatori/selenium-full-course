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
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }


        public void GoToPage(string url)
        {
            if (driver.Url == url)
            {
                return;
            }

            driver.Navigate().GoToUrl(url);
        }

        public void GoToMainPage()
        {
            if (driver.Url == baseURL + "/litecart/en/")
            {
                return;
            }

            driver.Navigate().GoToUrl(baseURL + "/litecart/en/");
        }

        public void GoToLoginPage()
        {
            if (driver.Url == baseURL + "/litecart/admin/n")
            {
                return;
            }

            driver.Navigate().GoToUrl(baseURL + "/litecart/admin/");
        }

        internal void GoToCountriesPage()
        {
            if (driver.Url == baseURL + "/litecart/admin/?app=countries&doc=countries")
            {
                return;
            }

            driver.Navigate().GoToUrl(baseURL + "/litecart/admin/?app=countries&doc=countries");
        }

        internal void GoToGeoZonesPage()
        {
            if (driver.Url == baseURL + "/litecart/admin/?app=geo_zones&doc=geo_zones")
            {
                return;
            }

            driver.Navigate().GoToUrl(baseURL + "/litecart/admin/?app=geo_zones&doc=geo_zones");
        }

        internal void GoToCreateAccountPage()
        {
            if (driver.Url == baseURL + "/litecart/en/create_account")
            {
                return;
            }

            driver.Navigate().GoToUrl(baseURL + "/litecart/en/create_account");
        }

        internal void GoToCatalogPage()
        {
            if (driver.Url == baseURL + "/litecart/admin/?app=catalog&doc=catalog")
            {
                return;
            }

            driver.Navigate().GoToUrl(baseURL + "/litecart/admin/?app=catalog&doc=catalog");
        }

        internal void GoToCartPage()
        {
            if (driver.Url == baseURL + "/litecart/en/checkout")
            {
                return;
            }

            driver.Navigate().GoToUrl(baseURL + "/litecart/en/checkout");
        }
    }
}
