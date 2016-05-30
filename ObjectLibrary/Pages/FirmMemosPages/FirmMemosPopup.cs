using ObjectLibrary.Shared;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary.Pages.FirmMemosPages
{
    public class FirmMemosPopup
    {
        public FirmMemosPopup()
        {
            PageFactory.InitElements(WebDriver.Driver, this);
        }

        [FindsBy(How = How.Id, Using = "button-1093-btnIconEl")]
        public static IWebElement BtnOk { get; set; }

        [FindsBy(How = How.Id, Using = "button-1094")]
        public IWebElement BtnCancel { get; set; }
    }
}
