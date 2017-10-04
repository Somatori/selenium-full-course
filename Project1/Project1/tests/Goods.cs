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
    public class Goods : TestBase
    {
        [Test]
        public void Goods_VerifyingOfItemProperties()
        {
            // prepare
            app.Navigator.GoToMainPage();

            // action

            //ItemData itemOnMainPage = new ItemData();
            //ItemData itemOnItemPage = new ItemData();

            List<string> itemOnMainPage = new List<string>();
            List<string> itemOnItemPage = new List<string>();

            IWebElement ItemOnMainPage = app.Pages.Main.TheFirstItemInCampaingsSection;
            // preparation items properties on Main page
            itemOnMainPage.Add(app.Pages.Main.ItemName(ItemOnMainPage).Text);
            itemOnMainPage.Add(app.Pages.Main.ItemRegularPrice(ItemOnMainPage).Text);
            itemOnMainPage.Add(app.Pages.Main.ItemCampaignPrice(ItemOnMainPage).Text);

            // verification of text-decoration-line on Main page
            string textDecorationValue = app.Items.GetTextDecorationValue(app.Pages.Main.
                ItemRegularPrice(ItemOnMainPage));
            Assert.IsTrue(textDecorationValue == "line-through");

            // verification of gray color on Main page
            string color = app.Pages.Main.ItemRegularPrice(ItemOnMainPage).GetCssValue("color"); //"rgba(119, 119, 119, 1)"
            string[] rgb = app.Items.RgbSeparation(color); // 119 119 119
            Assert.IsTrue(rgb[0] == rgb[1].Trim() && rgb[1].Trim() == rgb[2].Trim());

            // verification of font-weight on Main page
            Assert.IsTrue(app.Pages.Main.ItemCampaignPrice(ItemOnMainPage).GetCssValue("font-weight") == "bold" ||
                app.Pages.Main.ItemCampaignPrice(ItemOnMainPage).GetCssValue("font-weight") == "900" ||
                app.Pages.Main.ItemCampaignPrice(ItemOnMainPage).GetCssValue("font-weight") == "700");

            // verification of red color on Main page
            color = app.Pages.Main.ItemCampaignPrice(ItemOnMainPage).GetCssValue("color"); // "rgba(204, 0, 0, 1)"
            string[] rgb2 = app.Items.RgbSeparation(color);
            Assert.IsTrue(rgb2[1].Trim() == rgb2[2].Trim());

            // verification of difference in font sizes on Main page
            string fontSizeOfRegularPrice = app.Pages.Main.ItemRegularPrice(ItemOnMainPage)
                .GetCssValue("font-size"); // "14.4px"
            fontSizeOfRegularPrice = fontSizeOfRegularPrice.Substring(0, fontSizeOfRegularPrice.Length - 2); // 14.4
            string fontSizeOfCampaignPrice = app.Pages.Main.ItemCampaignPrice(ItemOnMainPage)
                .GetCssValue("font-size"); // "18px"
            fontSizeOfCampaignPrice = fontSizeOfCampaignPrice.Substring(0, fontSizeOfCampaignPrice.Length - 2); // 18
            Assert.IsTrue(Convert.ToDouble(fontSizeOfRegularPrice) < Convert.ToDouble(fontSizeOfCampaignPrice));

            ItemOnMainPage.Click();

            // preparation items properties on Item page
            itemOnItemPage.Add(app.Items.WaitForElement(app.Pages.Item.ItemName).Text);
            itemOnItemPage.Add(app.Pages.Item.ItemRegularPrice.Text);
            itemOnItemPage.Add(app.Pages.Item.ItemCampaignPrice.Text);

            // verification of properties on both pages
            Assert.AreEqual(itemOnMainPage, itemOnItemPage);

            // verification of text-decoration-line on Item page
            textDecorationValue = app.Items.GetTextDecorationValue(app.Pages.Item.ItemRegularPrice);
            Assert.IsTrue(textDecorationValue == "line-through");

            // verification of gray color on Item page
            color = app.Pages.Item.ItemRegularPrice.GetCssValue("color");
            string[] rgb3 = app.Items.RgbSeparation(color);
            Assert.IsTrue(rgb3[0] == rgb3[1].Trim() && rgb3[1].Trim() == rgb3[2].Trim());

            // verification of font-weight on Item page
            Assert.IsTrue(app.Pages.Item.ItemCampaignPrice.GetCssValue("font-weight") == "bold" ||
                app.Pages.Item.ItemCampaignPrice.GetCssValue("font-weight") == "700");

            // verification of red color on Item page
            color = app.Pages.Item.ItemCampaignPrice.GetCssValue("color");
            string[] rgb4 = app.Items.RgbSeparation(color);
            Assert.IsTrue(rgb4[1].Trim() == rgb4[2].Trim());

            // verification of difference in font sizes on Item page
            fontSizeOfRegularPrice = app.Pages.Item.ItemRegularPrice.GetCssValue("font-size"); 
            fontSizeOfRegularPrice = fontSizeOfRegularPrice.Substring(0, fontSizeOfRegularPrice.Length - 2);
            fontSizeOfCampaignPrice = app.Pages.Item.ItemCampaignPrice.GetCssValue("font-size"); 
            fontSizeOfCampaignPrice = fontSizeOfCampaignPrice.Substring(0, fontSizeOfCampaignPrice.Length - 2);
            Assert.IsTrue(Convert.ToDouble(fontSizeOfRegularPrice) < Convert.ToDouble(fontSizeOfCampaignPrice));
        }
    }
}
