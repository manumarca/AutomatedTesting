using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;
using System.Configuration;
using ObjectLibrary;
using OpenQA.Selenium.Remote;
using System.Diagnostics;

namespace AutomatedTesting.InternalActions.Shared
{
    public static class BrowserActions
    {
        public static void SetBrowser()
        {
            var config = ConfigurationSettings.AppSettings;
            switch (config["Browser"])
            {
                case "Firefox":
                    WebDriver.Driver = new FirefoxDriver();
                    Maximize();
                    break;
                case "Chrome":
                    WebDriver.Driver = new ChromeDriver();
                    Maximize();
                    break;
                case "Internet Explorer":
                    InternetExplorerOptions ieoptions = new InternetExplorerOptions();
                    ieoptions.EnableNativeEvents = false;
                    WebDriver.Driver = new InternetExplorerDriver(ieoptions);
                    Maximize();
                    break;
                case "Edge":
                    WebDriver.Driver = new EdgeDriver();
                    Maximize();
                    break;
                case "Opera":
                    OperaOptions option = new OperaOptions();
                    option.BinaryLocation = @"C:\Users\Manuel Marcatili\Documents\Visual Studio 2013\Projects\AutomatedTesting\packages\operadriver_win64";
                    WebDriver.Driver = new OperaDriver(option.BinaryLocation);
                    Maximize();
                    break;
                case "Safari":
                    WebDriver.Driver = new SafariDriver();
                    Maximize();
                    break;
            }
        }

        public static void Maximize()
        {
            WebDriver.Driver.Manage().Window.Maximize();
        }

        public static void CloseBrowser()
        {
            WebDriver.Driver.Close();
        }

        public static void GoToUrl(string url)
        {
            WebDriver.Driver.Navigate().GoToUrl(url);
        }

        public static void SwitchToFrame(IWebElement element)
        {
            WebDriver.Driver.SwitchTo().DefaultContent();
            WebDriver.Driver.SwitchTo().Frame(element);
        }

        public static void WaitForApplicationLoad(this IWebDriver driver)
        {
            Stopwatch _timer = new Stopwatch();
            _timer.Start();
            string loadingScreenId = "loading";
            bool isLoading = true;
            IWebElement loadingScreen;

            // Performs a loop until the loading screen disapears and while it take less than 10 seconds to load
            do
            {
                try
                {
                    // Searches for the loading screen div
                    loadingScreen = driver.FindElement(By.Id(loadingScreenId));
                }
                catch (NoSuchElementException)
                {
                    // Changes it to false if the loadingscreen is not found
                    isLoading = false;
                }
                // do while is going to be repeated until loadingScreen is true and it take less than 10 secs
            } while (isLoading && _timer.Elapsed < TimeSpan.FromSeconds(10));
        }
    }
}
