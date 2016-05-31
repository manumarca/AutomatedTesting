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
    public class FirmMemosAddAlertPopUp
    {
        public FirmMemosAddAlertPopUp()
        {
            PageFactory.InitElements(WebDriver.Driver, this);
        }

        [FindsBy(How = How.LinkText, Using = "Cancel")]
        public IWebElement CancelButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id[contains(., 'textfield') and contains(., 'inputEl')]]")]
        public IWebElement RSSFeedURLBox { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id[contains(., 'combobox') and contains(., 'inputCell')]]/div[@id[contains(., 'ext-gen')]]/following-sibling::input[@id[contains(., 'combobox')]]")]
        public IWebElement AlertNameTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = ".//td[@role='presentation']/label[contains(., 'RSS Feed')]/preceding-sibling::input[@id[contains(., 'radiofield')]]")]
        public IWebElement RssFeedRadiobutton { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Copy Link")]
        public IWebElement CopyLink { get; set; }
    }
}
