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
    public class ItemPage : AnyPage
    {
        public ItemPage(PageManager pages) : base(pages)
        {
        }


        [FindsBy(How = How.CssSelector, Using = "h1.title")]
        public IWebElement ItemName;

        [FindsBy(How = How.CssSelector, Using = "s.regular-price")]
        public IWebElement ItemRegularPrice;

        [FindsBy(How = How.CssSelector, Using = "strong.campaign-price")]
        public IWebElement ItemCampaignPrice;

        [FindsBy(How = How.Name, Using = "options[Size]")]
        public IWebElement SizeField;

        [FindsBy(How = How.Name, Using = "add_cart_product")]
        public IWebElement AddToCartButton;
    }
}