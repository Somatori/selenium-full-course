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
    public class CartPage : AnyPage
    {
        public CartPage(PageManager pages) : base(pages)
        {
        }


        [FindsBy(How = How.Name, Using = "remove_cart_item")]
        public IWebElement RemoveButton;

        [FindsBy(How = How.CssSelector, Using = "td.item")]
        public IList<IWebElement> ItemsInOrderSummaryTable;
    }
}