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
    }
}
