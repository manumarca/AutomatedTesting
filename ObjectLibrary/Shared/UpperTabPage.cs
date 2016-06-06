using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ObjectLibrary.Shared
{
    public class UpperTabPage
    {
        public UpperTabPage()
        {
            PageFactory.InitElements(WebDriver.Driver, this);
        }

        [FindsBy(How = How.Id, Using = "user_details_container")]
        public IWebElement UserDetailsIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[contains(@class, 'logout-link')]")]
        public IWebElement logoutLink { get; set; }

        [FindsBy(How = How.Id, Using = "combobox-1074-inputEl")]
        public IWebElement BillingReferenceTextBox { get; set; }

        [FindsBy(How = How.LinkText, Using = "Apply")]
        public IWebElement BillingReferenceApplyButton { get; set; }
        
        
    }
}
