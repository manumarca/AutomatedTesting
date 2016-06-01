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

        [FindsBy(How = How.Id, Using = "lawfirmfilter-inputEl")]
        public IWebElement LawFirmTextBoxFilter { get; set; }

        [FindsBy(How = How.Id, Using = "button-1019-btnInnerEl")]
        public IWebElement SearchButton { get; set; }

        [FindsBy(How = How.Id, Using = "button-1020-btnEl")]
        public IWebElement AddAlertButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id[contains(., 'tab') and contains(., 'closeEl')]]")]
        public IWebElement CloseFirstTab { get; set; }

        [FindsBy(How = How.Id, Using = "accountingfirmfilter-inputEl")]
        public IWebElement AccountFirmTextBoxFilter { get; set; }

        [FindsBy(How = How.Id, Using = "locationsfilter-1040-inputEl")]
        public IWebElement TopicTextBoxFilter { get; set; }

        
    }
}
