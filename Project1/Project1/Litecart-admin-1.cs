using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;


namespace litecart
{
    [TestFixture]
    public class LitecartAdmin1
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {

            //driver = new FirefoxDriver();
            driver = new ChromeDriver();
            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void LitecartAdminLogin()
        {
            driver.Url = "http://localhost/litecart/admin/";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a[href='http://localhost/litecart/admin/logout.php']")));
        }

        [Test]
        public void LitecartAdminMenu()
        {
            // login
            driver.Url = "http://localhost/litecart/admin/";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a[href='http://localhost/litecart/admin/logout.php']")));

            // menu
            int amountOfMenuItems = driver.FindElements(By.XPath("//li[@id='app-']/a")).Count;

            for (int i = 0; i < amountOfMenuItems; i++)
            {
                driver.FindElement(By.XPath("(//li[@id='app-']/a)[" + (i + 1) + "]")).Click();
                Assert.IsTrue(AreElementsPresent(By.CssSelector("h1")));

                int amountOfSubmenuItems = driver.FindElements(By.XPath("//li[@id='app-']//li/a")).Count;

                if (amountOfSubmenuItems > 0)
                {
                    for (int j = 1; j < amountOfSubmenuItems; j++)
                    {
                        driver.FindElement(By.XPath("(//li[@id='app-']//li/a)[" + (j + 1) + "]")).Click();
                        Assert.IsTrue(AreElementsPresent(By.CssSelector("h1")));
                    }
                }
            }
        }

        [Test]
        public void LitecartStickersForGoodsOnMainPage()
        {
            driver.Url = "http://localhost/litecart/en/";

            IList<IWebElement> goods = driver.FindElements(By.XPath("//div[@class='image-wrapper']"));
            int amountOfGoods = goods.Count;

            for (int i = 0; i < amountOfGoods; i++)
            {
                Assert.IsTrue(IsElementPresent(goods[i], By.CssSelector("div[class^='sticker ']")));
            }
        }

        public bool IsElementPresent(IWebElement webElement, By by)
        {
            try
            {
                webElement.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        bool AreElementsPresent(By locator)
        {
            return driver.FindElements(locator).Count > 0;
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}