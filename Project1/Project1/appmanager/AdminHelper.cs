﻿using System;
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
    public class AdminHelper : HelperBase
    {
        private PageManager pages;

        public AdminHelper(ApplicationManager manager) : base(manager)
        {
            this.pages = manager.Pages;
        }



    }
}
