using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Opera;
using NUnit.Framework;
using AutomatedTesting.Actions;
using ObjectLibrary.Shared;
using OpenQA.Selenium.Remote;
namespace AutomatedTesting
{
    class NukedEnviroment
    {
    
        [SetUp]
        public void Initialize()
        {
            //Set Basic XML 
            var config = ConfigurationSettings.AppSettings;
            //Set which browser is going to run
            BrowserActions.SetBrowser();
            //Goes to Intelligize
            BrowserActions.GoToUrl(config["Enviroment"]);
            //Gets Login Class
            LoginActions login = new LoginActions();
            //Logs In 
            login.EnterUser();
            login.EnterPassword();
            login.ClickOnSignIn();
        }

        [Test]
        public void ExecuteTest()
        {

            WebDriverWait wait = new WebDriverWait(WebDriver.Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.Id("ext-gen1089")));

        }

        [TearDown]
        public void TestCleanUp()
        {
            BrowserActions.CloseBrowser();
        }

        static void Main() { }
             

    }
}
