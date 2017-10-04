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
    public class InternalPage : AnyPage
    {
        public InternalPage(PageManager pages) : base(pages)
        {
        }


        [FindsBy(How = How.CssSelector, Using = "a[href='http://localhost/litecart/admin/logout.php']")]
        public IWebElement LogoutLink;

        [FindsBy(How = How.LinkText, Using = "Logout")]
        public IWebElement LogoutLinkInDropdownMenu;
    }
}