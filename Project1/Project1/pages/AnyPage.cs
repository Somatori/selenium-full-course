using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace litecart
{
    public class AnyPage
    {
        private PageManager pages;

        public AnyPage(PageManager pages)
        {
            this.pages = pages;
        }


        [FindsBy(How = How.CssSelector, Using = "i.icon-small-19-close[ng-click='cancel()']")]
        public IWebElement CloseIconInPopupWindow;


        public bool IsElementPresentAndVisible(By locator)
        {
            var driver = ApplicationManager.GetInstance().Driver;

            try
            {
                return driver.FindElement(locator).Displayed;
            }
            catch (Exception ex)
            {
                if (ex is NoSuchElementException || ex is ElementNotVisibleException 
                    || ex is StaleElementReferenceException)
                {
                    return false;
                }
                else if (ex.InnerException != null && ex.InnerException is StaleElementReferenceException)
                {
                    return false;
                }

                throw ex;
            }
        }

        public IWebElement WaitForElement(By locator)
        {
            var driver = ApplicationManager.GetInstance().Driver;
            bool isFound = false;

            for (int i = 0; i < 30; i++)
            {
                if (IsElementPresentAndVisible(locator))
                {
                    isFound = true;
                    break;
                }
                else
                {
                    System.Threading.Thread.Sleep(1000);
                }
            }

            if (isFound)
            {
                return driver.FindElement(locator); ;
            }
            else
            {
                Assert.Fail("ERROR! It's impossible to detect web-element.");
                return null;
            }
        }
    }
}