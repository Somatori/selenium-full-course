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
    public class CatalogPage_AddNewProduct : InternalPage
    {
        public CatalogPage_AddNewProduct(PageManager pages) : base(pages)
        {
        }

        [FindsBy(How = How.XPath, Using = "//input[@name='status' and @value='1'] ")]
        public IWebElement General_EnabledStatusRadioButton;

        [FindsBy(How = How.Name, Using = "name[en]")]
        public IWebElement General_NameField;

        [FindsBy(How = How.Name, Using = "code")]
        public IWebElement General_CodeField;

        [FindsBy(How = How.CssSelector, Using = "input[data-name='Rubber Ducks']")]
        public IWebElement General_RubberDucksCategory;

        [FindsBy(How = How.Name, Using = "default_category_id")]
        public IWebElement General_DefaultCategoryDropdown;

        [FindsBy(How = How.CssSelector, Using = "input[value='1-3']")]
        public IWebElement General_UnisexGender;

        [FindsBy(How = How.Name, Using = "quantity")]
        public IWebElement General_QuantityField;

        [FindsBy(How = How.Name, Using = "new_images[]")]
        public IWebElement General_BrowseButton;

        [FindsBy(How = How.Name, Using = "date_valid_from")]
        public IWebElement General_DateValidFromField;

        [FindsBy(How = How.Name, Using = "date_valid_to")]
        public IWebElement General_DateValidToField;

        [FindsBy(How = How.LinkText, Using = "Information")]
        public IWebElement InformationTab;

        [FindsBy(How = How.Name, Using = "manufacturer_id")]
        public IWebElement Information_ManufacturerField;

        [FindsBy(How = How.Name, Using = "keywords")]
        public IWebElement Information_KeywordsField;

        [FindsBy(How = How.Name, Using = "short_description[en]")]
        public IWebElement Information_ShortDescriptionField;

        [FindsBy(How = How.CssSelector, Using = "div.trumbowyg-editor")]
        public IWebElement Information_DescriptionField;

        [FindsBy(How = How.Name, Using = "head_title[en]")]
        public IWebElement Information_HeadTitleField;

        [FindsBy(How = How.Name, Using = "meta_description[en]")]
        public IWebElement Information_MetaDescriptionField;

        [FindsBy(How = How.LinkText, Using = "Prices")]
        public IWebElement PricesTab;

        [FindsBy(How = How.Name, Using = "purchase_price")]
        public IWebElement Prices_PurchasePriceField;

        [FindsBy(How = How.Name, Using = "purchase_price_currency_code")]
        public IWebElement Prices_CurrencyField;

        [FindsBy(How = How.Name, Using = "prices[USD]")]
        public IWebElement Prices_PriceUSDField;

        //[FindsBy(How = How.Name, Using = "gross_prices[USD]")]
        //public IWebElement Prices_PriceUSDWithTaxField;

        [FindsBy(How = How.Name, Using = "prices[EUR]")]
        public IWebElement Prices_PriceEURField;

        //[FindsBy(How = How.Name, Using = "gross_prices[EUR]")]
        //public IWebElement Prices_PriceEURWithTaxField;

        [FindsBy(How = How.Name, Using = "save")]
        public IWebElement SaveButton;
    }
}