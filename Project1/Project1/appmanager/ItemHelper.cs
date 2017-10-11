using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace litecart
{
    public class ItemHelper : HelperBase
    {
        private PageManager pages;

        public ItemHelper(ApplicationManager manager) : base(manager)
        {
            this.pages = manager.Pages;
        }


        public string[] RgbSeparation (string color)
        {
            string colorInRgb;
            char ch = '(';
            int indexOfChar = color.IndexOf(ch);
            if (indexOfChar == 4)
            {
                colorInRgb = color.Substring(5, color.Length - 9); // 119, 119, 119 
            }
            else
            {
                colorInRgb = color.Substring(4, color.Length - 5); // 119, 119, 119
            }

            return colorInRgb.Split(','); // 119 119 119
        }

        public string GetTextDecorationValue (IWebElement webElement)
        {
            if (webElement.GetCssValue("text-decoration-line") != "")
            {
                return webElement.GetCssValue("text-decoration-line");
            }
            else
            {
                return webElement.GetCssValue("text-decoration");
            }
        }

        public void AddTheFirstItemToCart()
        {
            manager.Navigator.GoToMainPage();
            WaitForElement(pages.Main.TheFirstItemInMostPopularSection).Click();

            int ItemsInCartBeforeAdding = Convert.ToInt32(WaitForElement(pages.Any.AmountOfItemsInCart).Text);
            string ItemsInCartAfterAdding = Convert.ToString((ItemsInCartBeforeAdding + 1));

            if (IsElementPresentAndVisible(pages.Item.SizeField))
            {
                new SelectElement(pages.Item.SizeField).SelectByIndex(1);
            }

            WaitForElement(pages.Item.AddToCartButton).Click();
            WaitForTextInElement(pages.Any.AmountOfItemsInCart, ItemsInCartAfterAdding);
        }

        public void RemoveItemFromCart()
        {
            manager.Navigator.GoToCartPage();
            IWebElement element = pages.Cart.ItemsInOrderSummaryTable[0];
            WaitForElement(pages.Cart.RemoveButton).Click();
            WaitForElementDisappearance(element);
        }
    }
}
