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
using AutomatedTesting.InternalActions;
using ObjectLibrary.Shared;
using ObjectLibrary.Pages.Home;
using ObjectLibrary.Pages.FirmMemosPages;
using OpenQA.Selenium.Remote;
using Repositories.cs;
using Repositories.cs.Helpers;

namespace AutomatedTesting
{
    class NukedEnviroment
    {



        
        [SetUp]
        public void Initialize()
        {
            //Set which browser is going to run
            BrowserActions.SetBrowser();
            //Gets Login Class
            LoginActions login = new LoginActions();
            //Goes to Intelligize
            BrowserActions.GoToUrl(ConfigurationSettings.AppSettings["Enviroment"]);
            //Logs In 
            login.Login();
        }

        [Test]
        public void ExecuteTest()
        {
            HomePage homePage = new HomePage();
            FirmMemosPage fmPage = new FirmMemosPage();
            FirmMemosPopup fmPopup = new FirmMemosPopup();
            homePage.FirmMemosLink.Click();
            PageObjectHelper.WaitForApplicationLoad(WebDriver.Driver);
            fmPage.LawFirmExpandFilter.Click();
            Thread.Sleep(1000);

            fmPage.LawFirmExpandFilter.ScrollIntoView(WebDriver.Driver);
            fmPage.LawFirmExpandFilter.Click();
            fmPopup.BtnCancel.Click();

        }

        [TearDown]
        public void TestCleanUp()
        {
            //Gets Logout Class
            LogoutActions logOut = new LogoutActions();
            //Logs Out from Application
            logOut.LogOut();
            //Closes Browser
            BrowserActions.CloseBrowser();
        }

        static void Main() { }
             

    }
}
