using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;

namespace litecart
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected ApplicationManager manager;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
        }

        public void Type(IWebElement webElement, string text)
        {
            if (text != null)
            {
                WaitForElement(webElement).Clear();
                webElement.SendKeys(text);
            }
        }

        public void ClickOnHiddenElement(IWebElement webElement)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(webElement).Perform();
            //actions.Perform();
            WaitForElement(webElement).Click();
        }

        public void MovetoElement (IWebElement webElement)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(webElement).Perform();
            //actions.Perform();
        }

        public String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmss");
            //return value.ToString("yyyyMMddHHmmssffff");
        }

        public String GetTimestampShort(DateTime value)
        {
            return value.ToString("HHmmss");
        }

        public bool IsElementPresent(IWebElement webElement)
        {
            string tagName;

            try
            {
                tagName = webElement.TagName;
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool AreElementsPresent(IList<IWebElement> webElements)
        {
            return webElements.Count > 0;
        }

        public bool IsElementPresentAndVisible(IWebElement webElement)
        {
            try
            {
                return webElement.Displayed;
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

        public IWebElement WaitForElement(IWebElement webElement)
        {
            bool isFound = false;

            for (int i = 0; i < 30; i++)
            {
                if (IsElementPresentAndVisible(webElement))
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
                return webElement;
            }
            else
            {
                //Assert.Fail("ERROR! It's impossible to detect web-element.");
                throw new TimeoutException();
            }
        }

        public IList<IWebElement> WaitForElements(IList<IWebElement> webElements)
        {
            bool isFound = false;

            for (int i = 0; i < 30; i++)
            {
                if (AreElementsPresent(webElements))
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
                return webElements;
            }
            else
            {
                Assert.Fail("ERROR! It's impossible to detect web-elements.");
                return null;
            }
        }

        public bool IsTextPresentAndVisibleInElement(IWebElement webElement, string text)
        {
            return (IsElementPresentAndVisible(webElement) && webElement.Text == text);
        }

        public bool WaitForTextInElement(IWebElement webElement, string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            return wait.Until(ExpectedConditions.TextToBePresentInElement(webElement, text));
        }

        public void ClosePopupWindow()
        {
            if (IsElementPresentAndVisible(manager.Pages.Any.CloseIconInPopupWindow))
            {
                manager.Pages.Any.CloseIconInPopupWindow.Click();
            }
        }

        public void ClickSeveralTimes(IWebElement webElement)
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    webElement.Click();
                    break;
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null && ex.InnerException is InvalidOperationException)
                    {
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }
        }

        public bool WaitForElementDisappearance(IWebElement webElement)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            return wait.Until(ExpectedConditions.StalenessOf(webElement));
        }
    }
}