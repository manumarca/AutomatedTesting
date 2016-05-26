using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ObjectLibrary.Shared;

namespace ObjectLibrary.Pages.LogIn
{
    public class LoginPage
    {
        public LoginPage()
        {
            PageFactory.InitElements(WebDriver.Driver, this);
        }

        [FindsBy(How = How.Id, Using = "UserName")]
        public IWebElement UserName{ get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement PassWord { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        public IWebElement LogInButton { get; set; }
    }
}
