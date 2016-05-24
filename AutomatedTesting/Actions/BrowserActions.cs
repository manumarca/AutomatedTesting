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
using System.Configuration;
using ObjectLibrary.Shared;
using OpenQA.Selenium.Remote;

namespace AutomatedTesting.Actions
{
    public static class BrowserActions
    {
        public static void SetBrowser()
        {
            var config = ConfigurationSettings.AppSettings;
            WebDriver.Driver driver;
            switch (config["Browser"])
            {
                case "Firefox":
                    WebDriver.Driver = new FirefoxDriver();
                    break;
                case "Chrome":
                    WebDriver.Driver = new ChromeDriver();
                    
                    break;
                case "Internet Explorer":
                     driver = new InternetExplorerDriver();
                    break;
                case "Edge":
                    WebDriver.Driver = new EdgeDriver();
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
