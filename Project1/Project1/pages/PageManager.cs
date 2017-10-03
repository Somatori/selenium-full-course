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
    }
}