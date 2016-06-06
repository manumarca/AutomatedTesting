using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ObjectLibrary.Shared;

namespace ObjectLibrary.Pages.Home
{
    public class HomePage
    {
        public HomePage()
        {
            PageFactory.InitElements(WebDriver.Driver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//*[@id='mainApplicationMenu']/div/ul[4]/li[2]/div/span")]
        public IWebElement FirmMemosLink{ get; set; }

    }
}
