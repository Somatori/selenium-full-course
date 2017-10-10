using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace litecart
{
    public class PageManager
    {
        protected IWebDriver driver;
        protected ApplicationManager manager;

        public PageManager(ApplicationManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;

            Any = InitElements(new AnyPage(this));
            Internal = InitElements(new InternalPage(this));
            Login = InitElements(new LoginPage(this));
            Countries = InitElements(new CountriesPage(this));
            GeoZones = InitElements(new GeoZonesPage(this));
            Main = InitElements(new MainPage(this));
            Item = InitElements(new ItemPage(this));
            CustomerLogin = InitElements(new CustomerLoginPage(this));
            Registration = InitElements(new CreateAccountPage(this));
            Catalog = InitElements(new CatalogPage(this));
            Catalog_AddNewProduct = InitElements(new CatalogPage_AddNewProduct(this));


        }

        private T InitElements<T>(T page) where T : AnyPage
        {
            PageFactory.InitElements(driver, page);
            return page;
        }

        public AnyPage Any { get; set; }
        public InternalPage Internal { get; set; }
        public LoginPage Login { get; set; }
        public CountriesPage Countries { get; set; }
        public GeoZonesPage GeoZones { get; set; }
        public MainPage Main { get; set; }
        public ItemPage Item { get; set; }
        public CustomerLoginPage CustomerLogin { get; set; }
        public CreateAccountPage Registration { get; set; }
        public CatalogPage Catalog { get; set; }
        public CatalogPage_AddNewProduct Catalog_AddNewProduct { get; set; }



    }
}