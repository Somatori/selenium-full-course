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
    public class Cart : TestBase
    {
        [Test]
        public void Cart_AddAndRemoveItems()
        {
            // add items to cart
            for (int i = 0; i < 3; i++)
            {
                app.Items.AddTheFirstItemToCart();
            }

            app.Pages.Any.CheckoutLink.Click(); // go to 'Cart' page

            int amountOfDifferentItemsInCart = app.Items.WaitForElements(app.Pages.Cart
                .ItemsInOrderSummaryTable).Count;

            for (int i = 0; i < amountOfDifferentItemsInCart; i++)
            {
                app.Items.RemoveItemFromCart();
            }
        }
    }
}
