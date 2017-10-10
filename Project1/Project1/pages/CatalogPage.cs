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
    public class CatalogPage : InternalPage
    {
        public CatalogPage(PageManager pages) : base(pages)
        {
        }


        [FindsBy(How = How.XPath, Using = "//a[@class='button'][2]")]
        public IWebElement AddNewProductButton;


        public IWebElement Product(string name)
        {
            By locator = By.XPath("//table [@class='dataTable']//a[text()='" + name + "']");
            return WaitForElement(locator);
        }
    }
}