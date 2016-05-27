using ObjectLibrary.Shared;
using OpenQA.Selenium;
using Repositories.cs.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;

namespace AutomatedTesting.InternalActions
{
    public class LogoutActions
    {
        private static UpperTabPage ut = new UpperTabPage();

        public void LogOut ()
        {
            ClickUserDetailsIcon();
            ClickLogOut();
            
        }

        public void ClickUserDetailsIcon()
        {
            ut.UserDetailsIcon.FindElementWaitUntilClickable(WebDriver.Driver);
            ut.UserDetailsIcon.Click();
 
        }

        public void ClickLogOut()
        {
            ut.logoutLink.FindElementWaitUntilClickable(WebDriver.Driver);
            ut.logoutLink.Click();
            
        }
    }
}
