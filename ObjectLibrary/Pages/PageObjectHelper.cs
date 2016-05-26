using ObjectLibrary.Shared;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.cs.Helpers
{
    public static class PageObjectHelper
    {
        private static TimeSpan timeOut = TimeSpan.FromSeconds(10);
        private static WebDriverWait wait;
        private static IWebElement elementToBeLocated;


        public static IWebElement FindElementWaitUntilExists(By locator)
        {
            wait = new WebDriverWait(WebDriver.Driver, timeOut);
            elementToBeLocated = wait.Until(ExpectedConditions.ElementExists(locator));
            return elementToBeLocated;
        }

        public static IWebElement FindElementWaitUntilVisible(By locator)
        {
            wait = new WebDriverWait(WebDriver.Driver, timeOut);
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static IWebElement FindElementWaitUntilClickable(IWebElement locator)
        {
            wait = new WebDriverWait(WebDriver.Driver, timeOut);
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }
    }
}
