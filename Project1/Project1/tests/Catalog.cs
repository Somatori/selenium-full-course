﻿using System;
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
    public class Catalog : AuthTestBase
    {
        [Test]
        public void Catalog_AddNewProduct()
        {
            // prepare
            string timeStamp = app.Customer.GetTimestamp(DateTime.Now);
            string productName = "Tennis Duck - " + timeStamp;
            string pathToImage = AppDomain.CurrentDomain.BaseDirectory + "TennisDuck.jpg";

            // open 'Add New Product' page
            app.Navigator.GoToCatalogPage();
            app.Pages.Catalog.AddNewProductButton.Click();

            // fill the form on the 'General' tab
            app.Catalog.WaitForElement(app.Pages.Catalog_AddNewProduct.General_EnabledStatusRadioButton).Click(); // Status
            app.Catalog.Type(app.Pages.Catalog_AddNewProduct.General_NameField, productName); // Name
            app.Catalog.Type(app.Pages.Catalog_AddNewProduct.General_CodeField, timeStamp); // Code
            app.Pages.Catalog_AddNewProduct.General_RubberDucksCategory.Click(); // Category
            new SelectElement(app.Pages.Catalog_AddNewProduct.General_DefaultCategoryDropdown)
                .SelectByText("Rubber Ducks"); // Default Category
            app.Pages.Catalog_AddNewProduct.General_UnisexGender.Click(); // Gender
            app.Catalog.Type(app.Pages.Catalog_AddNewProduct.General_QuantityField, "100"); // Quantity
            app.Pages.Catalog_AddNewProduct.General_BrowseButton.SendKeys(pathToImage); // Image
            app.Catalog.Type(app.Pages.Catalog_AddNewProduct.General_DateValidFromField, "2017-01-01"); // Date Valid From
            app.Catalog.Type(app.Pages.Catalog_AddNewProduct.General_DateValidToField, "2018-01-01"); // Date Valid To

            // fill the form on the 'Information' tab
            app.Pages.Catalog_AddNewProduct.InformationTab.Click();
            new SelectElement(app.Catalog.WaitForElement(app.Pages.Catalog_AddNewProduct
                .Information_ManufacturerField)).SelectByText("ACME Corp."); // Manufacturer
            app.Catalog.Type(app.Pages.Catalog_AddNewProduct.Information_KeywordsField, "tennis, duck"); // Keywords
            app.Catalog.Type(app.Pages.Catalog_AddNewProduct.Information_ShortDescriptionField, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse sollicitudin ante massa, eget ornare libero porta congue."); // Short Description
            app.Pages.Catalog_AddNewProduct.Information_DescriptionField.Click();
            app.Catalog.Type(app.Pages.Catalog_AddNewProduct.Information_DescriptionField, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse sollicitudin ante massa, eget ornare libero porta congue. Cras scelerisque dui non consequat sollicitudin. Sed pretium tortor ac auctor molestie. Nulla facilisi. Maecenas pulvinar nibh vitae lectus vehicula semper. Donec et aliquet velit. Curabitur non ullamcorper mauris. In hac habitasse platea dictumst. Phasellus ut pretium justo, sit amet bibendum urna. Maecenas sit amet arcu pulvinar, facilisis quam at, viverra nisi. Morbi sit amet adipiscing ante. Integer imperdiet volutpat ante, sed venenatis urna volutpat a. Proin justo massa, convallis vitae consectetur sit amet, facilisis id libero. "); // Description
            app.Catalog.Type(app.Pages.Catalog_AddNewProduct.Information_HeadTitleField, "Tennis Rubber Duck"); // Head Title
            app.Catalog.Type(app.Pages.Catalog_AddNewProduct.Information_MetaDescriptionField, "cool duck"); // Meta Description

            // fill the form on the 'Prices' tab
            app.Pages.Catalog_AddNewProduct.PricesTab.Click();
            app.Catalog.Type(app.Catalog.WaitForElement(app.Pages.Catalog_AddNewProduct
                .Prices_PurchasePriceField), "3"); // Purchase Price
            new SelectElement(app.Pages.Catalog_AddNewProduct.Prices_CurrencyField)
                .SelectByText("US Dollars"); // Currency
            app.Catalog.Type(app.Pages.Catalog_AddNewProduct.Prices_PriceUSDField, "5"); // Price USD
            app.Catalog.Type(app.Pages.Catalog_AddNewProduct.Prices_PriceEURField, "4"); // Price EUR

            // save
            app.Pages.Catalog_AddNewProduct.SaveButton.Click();

            // verification
            IWebElement createdProduct = app.Catalog.WaitForElement(app.Pages.Catalog.Product(productName));
            Assert.IsTrue(app.Catalog.IsElementPresent(createdProduct));
        }
    }
}
