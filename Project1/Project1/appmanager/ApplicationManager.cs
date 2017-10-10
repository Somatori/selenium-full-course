using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace litecart
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected PageManager pageManager;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected ItemHelper itemHelper;
        protected CustomerAccountHelper customerAccountHelper;
        protected CatalogHelper catalogHelper;


        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            //driver = new EdgeDriver();
            driver = new FirefoxDriver();
            //driver = new ChromeDriver();
            //driver.Manage().Window.Size = new Size(1280, 768);
            baseURL = "http://localhost";

            pageManager = new PageManager(this);

            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            itemHelper = new ItemHelper(this);
            customerAccountHelper = new CustomerAccountHelper(this);
            catalogHelper = new CatalogHelper(this);

        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }


        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                //newInstance.Navigator.GoToLoginPage();
                app.Value = newInstance;
            }
            return app.Value;
        }
        
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public PageManager Pages
        {
            get
            {
                return pageManager;
            }
        }

        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }

        public NavigationHelper Navigator
        {
            get
            {
                return navigator;
            }
        }

        public ItemHelper Items
        {
            get
            {
                return itemHelper;
            }
        }

        public CustomerAccountHelper Customer
        {
            get
            {
                return customerAccountHelper;
            }
        }

        public CatalogHelper Catalog
        {
            get
            {
                return catalogHelper;
            }
        }
    }
}
