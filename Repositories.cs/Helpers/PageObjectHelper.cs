using ObjectLibrary.Shared;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Repositories.cs.Helpers
{
    public static class PageObjectHelper
    {
        private static TimeSpan timeOut = TimeSpan.FromSeconds(10);
        private static WebDriverWait wait;
        private static IWebElement elementToBeLocated;
        private static Actions actions;


        public static IWebElement FindElementWaitUntilExists(By locator, IWebDriver driver)
        {
            wait = new WebDriverWait(driver, timeOut);
            elementToBeLocated = wait.Until(ExpectedConditions.ElementExists(locator));
            return elementToBeLocated;
        }

        public static IWebElement FindElementWaitUntilVisible(By locator, IWebDriver driver)
        {
            driver.SwitchTo().Window(driver.CurrentWindowHandle);
            wait = new WebDriverWait(driver, timeOut);
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static IWebElement FindElementWaitUntilClickable(this IWebElement locator,IWebDriver driver)
        {
            driver.SwitchTo().Window(driver.CurrentWindowHandle);
            wait = new WebDriverWait(driver, timeOut);
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public static void JsClick(this IWebElement element, IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
        }
        public static void WaitForAjax(this IWebDriver driver, int timeoutSecs = 10, bool throwException = false)
        {
            for (var i = 0; i < timeoutSecs; i++)
            {
                var ajaxIsComplete = (bool)(driver as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0");
                if (ajaxIsComplete) return;
                Thread.Sleep(1000);
            }
            if (throwException)
            {
                throw new Exception("WebDriver timed out waiting for AJAX call to complete");
            }
        }

        public static void ResetLayer(this IWebElement element, IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(" + element.Location.Y + "," + element.Location.Y + ")");
        }

        public static void ScrollIntoView(this IWebElement element, IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public static IList<IWebElement> GetRowsFromTable(this IWebElement element)
        {
           return element.FindElements(By.TagName("tr"));
        }
      
    }
}
