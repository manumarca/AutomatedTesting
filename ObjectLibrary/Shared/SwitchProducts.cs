using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ObjectLibrary.Shared
{
    public class SwitchProducts
    {
        public SwitchProducts()
        {
            PageFactory.InitElements(WebDriver.Driver, this);
        }

        [FindsBy(How = How.Id, Using = "_switch_product_button")]
        public static IWebElement SwitchProduct { get; set; }

        [FindsBy(How = How.Id, Using = "button-1019-btnInnerEl")]
        public static IWebElement SearchButton { get; set; }
    }
}
