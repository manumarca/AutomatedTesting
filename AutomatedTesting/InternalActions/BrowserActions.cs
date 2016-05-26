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
using ObjectLibrary.Shared;
using OpenQA.Selenium.Remote;

namespace AutomatedTesting.InternalActions
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
                    break;
                case "Chrome":
                    WebDriver.Driver = new ChromeDriver();  
                    break;
                case "Internet Explorer":
                    WebDriver.Driver = new InternetExplorerDriver();
                    break;
                case "Edge":
                    WebDriver.Driver = new EdgeDriver();
                    break;
                case "Opera":
                    OperaOptions option = new OperaOptions();
                    option.BinaryLocation = @"C:\Users\Manuel Marcatili\Documents\Visual Studio 2013\Projects\AutomatedTesting\packages\operadriver_win64";
                    WebDriver.Driver = new OperaDriver(option.BinaryLocation);
                    break;
                case "Safari":
                    WebDriver.Driver = new SafariDriver();
                    break;
            }
        }

        public static void CloseBrowser()
        {
            WebDriver.Driver.Close();
        }

        public static void GoToUrl(string url)
        {
            WebDriver.Driver.Navigate().GoToUrl(url);
        }
    }
}
