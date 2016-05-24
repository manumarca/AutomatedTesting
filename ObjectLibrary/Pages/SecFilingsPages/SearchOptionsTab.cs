using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ObjectLibrary.Shared;

namespace ObjectLibrary.Pages.SecFilingsPages
{
    public class SearchOptionsTab
    {
        public SearchOptionsTab()
        {
            PageFactory.InitElements(WebDriver.Driver, this);
        }

        [FindsBy(How = How.Id, Using= "button-1019-btnInnerEl")]
        public IWebElement SearchButton{get;set;}
    }
}
