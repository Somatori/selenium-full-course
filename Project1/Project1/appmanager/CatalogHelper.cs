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
    public class CatalogHelper : HelperBase
    {
        private PageManager pages;

        public CatalogHelper(ApplicationManager manager) : base(manager)
        {
            this.pages = manager.Pages;
        }



    }
}
