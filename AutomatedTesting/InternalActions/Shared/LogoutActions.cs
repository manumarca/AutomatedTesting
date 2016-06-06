using ObjectLibrary;
using OpenQA.Selenium;
using Repositories.cs.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;

namespace AutomatedTesting.InternalActions.Shared
{
    public class LogoutActions
    {
        private static PageObjectCaller poc = new PageObjectCaller();

        public void LogOut ()
        {
            ClickUserDetailsIcon();
            ClickLogOut();
        }

        public void ClickUserDetailsIcon()
        {
            poc.UpperTabPage.UserDetailsIcon.ResetLayer(WebDriver.Driver);
            poc.UpperTabPage.UserDetailsIcon.WaitUntilClickable(WebDriver.Driver);
            poc.UpperTabPage.UserDetailsIcon.Click();
        }

        public void ClickLogOut()
        {
            poc.UpperTabPage.logoutLink.WaitUntilClickable(WebDriver.Driver);
            poc.UpperTabPage.logoutLink.Click();
        }
    }
}
