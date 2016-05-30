using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ObjectLibrary.Shared;

namespace ObjectLibrary.Pages.FirmMemosPages
{
    public class FirmMemosPage
    {
        public FirmMemosPage()
        {
            PageFactory.InitElements(WebDriver.Driver, this);
        }

        [FindsBy(How = How.Id, Using = "ext-gen1132")]
        public IWebElement LawFirmExpandFilter { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='button-1094-btnIconEl']")]
        public IWebElement LawFirmCancelFilter { get; set; }

        [FindsBy(How = How.Id, Using = "ext-gen1251")]
        public IWebElement LawFirmFrameFilter { get; set; }

        [FindsBy(How = How.Id, Using = "ext-comp-1077-body")]
        public IWebElement LawFirmListFilter { get; set; }

        [FindsBy(How = How.Id, Using = "textfilter-1129-inputEl")]
        public IWebElement LawFirmTextBoxFilter { get; set; }
        
    }
}
